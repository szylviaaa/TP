//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TP.GraphicalData.Model;
using TP.GraphicalData.ViewModel.MVVMLight;

namespace TP.GraphicalData.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
    #region constructors

    public MainViewModel()
    {
      ShowTreeViewMainWindowCommend = new RelayCommand(ShowTreeViewMainWindow);
      FetchDataCommend = new RelayCommand(() => DataLayer = new DataLayer());
      DisplayTextCommand = new RelayCommand(ShowPopupWindow, () => !string.IsNullOrEmpty(m_ActionText));
      m_ActionText = "Text to be displayed on the popup";
    }

    #endregion constructors

    #region ViewModel API

    public ObservableCollection<User> Users
    {
      get => m_Users;
      set
      {
        m_Users = value;
        RaisePropertyChanged();
      }
    }

    public User CurrentUser
    {
      get => m_CurrentUser;
      set
      {
        m_CurrentUser = value;
        RaisePropertyChanged();
      }
    }

    public string ActionText
    {
      get => m_ActionText;
      set
      {
        m_ActionText = value;
        DisplayTextCommand.RaiseCanExecuteChanged();
        RaisePropertyChanged();
      }
    }

    public RelayCommand DisplayTextCommand
    {
      get; private set;
    }

    public RelayCommand FetchDataCommend
    {
      get; private set;
    }

    public ICommand ShowTreeViewMainWindowCommend
    {
      get; private set;
    }

    public Lazy<IWindow> ChildWindow { get; set; }

    #endregion ViewModel API

    #region Unit test instrumentation

    /// <summary>
    /// Gets or sets the message box show delegate.
    /// </summary>
    /// <remarks>
    /// It is to be used by unit test to override default popup. Limited access ability is addressed by explicate allowing unit test assembly to access internals
    /// using <see cref="System.Runtime.CompilerServices.InternalsVisibleToAttribute"/>.
    /// </remarks>
    /// <value>The message box show delegate.</value>
    public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");

    public DataLayer DataLayer
    {
      get => m_DataLayer;
      set
      {
        m_DataLayer = value;
        Users = new ObservableCollection<User>(value.User);
      }
    }

    #endregion Unit test instrumentation

    #region Private stuff

    private DataLayer m_DataLayer;
    private User m_CurrentUser;
    private string m_ActionText;
    private ObservableCollection<User> m_Users;

    private void ShowPopupWindow()
    {
      MessageBoxShowDelegate(ActionText);
    }

    private void ShowTreeViewMainWindow()
    {
      IWindow _child = ChildWindow.Value;
      _child.Show();
    }

    #endregion Private stuff
  }
}