using Microsoft.Maui.Controls.Hosting;
using System.Collections.ObjectModel;

namespace Mirror_Image_Photography;

public partial class Contact : ContentPage
{
    public Contact()
    {
        InitializeComponent();

        
    }


    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        var name = nameEntry.Text;
        var email = emailEntry.Text;
        var phone = phoneEntry.Text;
        var subject = subjectEntry.Text;
        var message = messageEditor.Text;

        // TODO: Send the contact form data to your backend or via email

        await DisplayAlert("Thank you", "Your message has been sent.", "OK");
    }
}

    
