using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp;

public class Address
{
    public Address(int houseNo, string street, string town)
    {
        HouseNo = houseNo;
        Street = street;
        Town = town;
    }
    public string GetAddres()
    {
        return $"{HouseNo} {Street}, {Town}";
    }
    public int HouseNo { get; set; }
    public string Street { get; set; }
    public string Town { get; set; }
    
}
