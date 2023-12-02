using System.Collections.Generic;
using RentServiceFront.domain.model.entity;

namespace RentServiceFront.viewmodel.authentication;

public class AddressViewModel : ViewModelBase
{
    private string _name;
    private List<AddressPart> _addressParts;
    public AddressViewModel(string name, List<AddressPart> addressParts)
    {
        Name = name;
        AddressParts = addressParts;
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChange(nameof(Name));
        }
    }

    public List<AddressPart> AddressParts
    {
        get => _addressParts;
        set
        {
            _addressParts = value;
            OnPropertyChange(nameof(AddressParts));
        }
    }
}