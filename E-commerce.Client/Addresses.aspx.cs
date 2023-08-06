using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client
{
    public partial class Addresses : System.Web.UI.Page
    {
        AddressController addressController = new AddressController();
        protected void Page_Load(object sender, EventArgs e)
        {
             GenerateAddressTable();

        }

        protected void GenerateAddressTable()
        {
            IEnumerable<Address> addresses = addressController.GetAllAddresses();
            StringBuilder addressesStringBuilder = new StringBuilder("");
            addressesStringBuilder.Append("<table border='1'>");
            addressesStringBuilder.Append("<tr>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>Id</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>User_ID</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>Address Line 1</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>Address Line 2</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>City</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>Postal Code</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>Country</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'>Region</th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            addressesStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            addressesStringBuilder.Append("</tr>");

            foreach (Address address in addresses)
            {
                addressesStringBuilder.Append("<tr>");
                // Address ID
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Id);
                addressesStringBuilder.Append("</td>");
                // User ID
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.User_Id);
                addressesStringBuilder.Append("</td>");
                // Address Line 1
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Address_line1);
                addressesStringBuilder.Append("</td>");
                // Address Line 2
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Address_line2);
                addressesStringBuilder.Append("</td>");
                // City
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.City);
                addressesStringBuilder.Append("</td>");
                // Postal Code
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Postal_code);
                addressesStringBuilder.Append("</td>");
                // Country
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Country);
                addressesStringBuilder.Append("</td>");
                // Region
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Region);
                addressesStringBuilder.Append("</td>");
                // Edit Button
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append("<button type='button' class='edit-button' data-id='" + address.Id + "'>Edit</button>");
                addressesStringBuilder.Append("</td>");
                // Delete Buttons
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append("<button type='button' class='delete-button' data-id='" + address.Id + "'> Delete </button>");
                addressesStringBuilder.Append("</td>");

                addressesStringBuilder.Append("</tr>");
            }

            addressesStringBuilder.Append("</table>");
            AddressTable.Text = addressesStringBuilder.ToString();
        }
    }
}