﻿using System.Collections.Generic;

namespace RentServiceFront.viewmodel;

public class MainViewModel : ViewModelBase
{
    private List<SampleItem> _sampleItems;
    private SampleItem _selectedItem;
    private ViewModelBase _currentViewModel;
    
    public MainViewModel(List<SampleItem> sampleItems)
    {
        SampleItems = sampleItems;
        _selectedItem = sampleItems[0];
        _currentViewModel = _selectedItem.ViewModel;
        _currentViewModel.ViewModelRequested += OnViewModelChanged;
    }
    
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel.ViewModelRequested -= OnViewModelChanged; 
            _currentViewModel = value;
            _currentViewModel.ViewModelRequested += OnViewModelChanged; 
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }

    public List<SampleItem> SampleItems
    {
        get => _sampleItems;
        set
        {
            _sampleItems = value;
            OnPropertyChange(nameof(SampleItems));
        }
    }

    public SampleItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            CurrentViewModel = _selectedItem.ViewModel;
            OnPropertyChange(nameof(SelectedItem));
        }
    }
    
    private void OnViewModelChanged(object? sender, ViewModelBase e)
    {
        CurrentViewModel = e;
        _selectedItem = null;
        OnPropertyChange(nameof(SelectedItem));
    }
}