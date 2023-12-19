using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RentServiceFront.data.authentication.api_request;
using RentServiceFront.data.secure;
using RentServiceFront.domain.authentication.use_case;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.enums;

namespace RentServiceFront.viewmodel.mainWindow;

public class AccountViewModel : ViewModelBase
{
    private SecureDataStorage _secureDataStorage; 
    private List<SampleItem> _sampleItems;
    private SampleItem _selectedItem;
    private ViewModelBase _currentViewModel;

    public AccountViewModel(SecureDataStorage secureDataStorage, List<SampleItem> sampleItems)
    {
        _secureDataStorage = secureDataStorage ?? throw new ArgumentException("Secure data storage can't be null");
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