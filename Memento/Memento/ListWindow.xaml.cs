﻿using Memento.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memento;

/// <summary>
/// Interaction logic for ListWindow.xaml
/// </summary>
public partial class ListWindow : Window
{
    //private ObservableCollection<TaskMemento> ChangesList = new ObservableCollection<TaskMemento>();
    public ListWindow()
    {
        InitializeComponent();
    }

    public ListWindow(List<string> uSERs) : this() 
    {
        for (int i = 0; i < uSERs.Count; i++)
        {
            this.changeNotes.Items.Add(uSERs[i]);
        }
        
    }
}
