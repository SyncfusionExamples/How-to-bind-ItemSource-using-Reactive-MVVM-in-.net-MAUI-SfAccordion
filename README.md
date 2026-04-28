# How to Bind ItemsSource Using Reactive MVVM in .NET MAUI SfAccordion

**Repository Description**  
This repository contains a .NET MAUI sample that demonstrates how to bind the `ItemsSource` of the Syncfusion **[SfAccordion](https://help.syncfusion.com/maui/accordion/getting-started)** control using the **Reactive MVVM** pattern with ReactiveUI.

The sample illustrates how to integrate ReactiveUI with Syncfusion MAUI controls to create a composable and cross‑platform MVVM architecture for .NET MAUI applications.

## Project Overview
The purpose of this project is to help developers understand how to implement reactive data binding for the SfAccordion control in a .NET MAUI application. It showcases binding hierarchical data through a ReactiveUI ViewModel and dynamically rendering accordion items based on observable collections.

## Features
- Integration of Syncfusion .NET MAUI SfAccordion control  
- Bind `ItemsSource` using ReactiveUI‑based MVVM  
- Reactive ViewModel implementation using [ReactiveObject](https://www.reactiveui.net/docs/handbook/view-models/)
- Dynamic rendering of accordion headers and content  
- Support for item tap interactions using reactive commands  

## Prerequisites
Ensure the following requirements are met before running this project:
- Visual Studio 2022  
- .NET SDK compatible with .NET MAUI  
- NuGet packages:
  - [ReactiveUI](https://www.nuget.org/packages/ReactiveUI/)
  - [ReactiveUI.Maui](https://www.nuget.org/packages/ReactiveUI.Maui/)  

## Installation
1. Clone the repository to your local machine.
2. Open the solution using Visual Studio 2022.
3. Restore NuGet packages by rebuilding the solution.
4. Ensure the required Syncfusion MAUI packages are referenced.


## ViewModel:

```csharp
public class ViewModel : ReactiveObject
{
    private ObservableCollection<ContactInfo> contacts;

    public ObservableCollection<ContactInfo> Contacts
    {
        get
        {
            return this.contacts;
        }

        set
        {
            this.RaiseAndSetIfChanged(ref contacts, value);
        }
    }

    public Command<object> TapCommand { get; set; }

    public ViewModel()
    {
        Contacts = new ObservableCollection<ContactInfo>();
        TapCommand = new Command<object>(OnTapped);
        Contacts.Add(new ContactInfo() { Type = "A", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Adam" }, new Contact { ContactName = "Aaron" } } });
        Contacts.Add(new ContactInfo() { Type = "B", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Bolt" }, new Contact { ContactName = "Bush" } } });
        Contacts.Add(new ContactInfo() { Type = "C", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Clark" }, new Contact { ContactName = "Clara" } } });
    }

    private void OnTapped(object obj)
    {
        var data = obj as Contact;
        App.Current.MainPage.DisplayAlert("Message", "Tapped Accoridon item is : " + data.ContactName, "Ok");
    }
}

```

STEP 3: ContentPage should inherit from ReactiveContentPage<TViewModel> and we are going to use ReactiveUI Binding to bind our ViewModel to our View.

**XAML:**

```xml
<rxui:ReactiveContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                          xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                          x:Class="GettingStarted.MainPage" 
                          x:TypeArguments="local:ViewModel"
                          xmlns:local="clr-namespace:GettingStarted"
                          xmlns:rxui="clr-namespace:ReactiveUI.Maui;assembly=ReactiveUI.Maui"
                          xmlns:syncfusion="clr-namespace:Syncfusion.Maui.Accordion;assembly=Syncfusion.Maui.Expander"
                          xmlns:sflistview="clr-namespace:Syncfusion.Maui.ListView;assembly=Syncfusion.Maui.ListView">

    <StackLayout>
        <syncfusion:SfAccordion x:Name="Accordion" BindableLayout.ItemsSource="{Binding Contacts}" ExpandMode="SingleOrNone" >
            <BindableLayout.ItemTemplate>
                <DataTemplate>
                    <syncfusion:AccordionItem>
                        <syncfusion:AccordionItem.Header >
                            <Grid HeightRequest="60">
                                <Label Text="{Binding Type}" BackgroundColor="Aqua" VerticalTextAlignment="Center" HorizontalTextAlignment="Center"/>
                            </Grid>
                        </syncfusion:AccordionItem.Header>
                        <syncfusion:AccordionItem.Content>
                            <Grid x:Name="mainGrid" Padding="4" HeightRequest="135" >
                                <sflistview:SfListView AllowGroupExpandCollapse="True" IsScrollingEnabled="False" x:Name="listView" AutoFitMode="DynamicHeight"
                                    ItemSpacing="3" ItemsSource="{Binding Contacts}" >
                                    <sflistview:SfListView.ItemTemplate>
                                        <DataTemplate>
                                            <Grid HeightRequest="60" Padding="1" >
                                                <Label Text="{Binding ContactName}" BackgroundColor="LightBlue"/>
                                                <Grid.GestureRecognizers>
                                                    <TapGestureRecognizer Command="{Binding Path=BindingContext.TapCommand, Source={x:Reference Accordion}}" CommandParameter="{Binding .}" />
                                                </Grid.GestureRecognizers>
                                            </Grid>
                                        </DataTemplate>
                                    </sflistview:SfListView.ItemTemplate>
                                </sflistview:SfListView>
                            </Grid>
                        </syncfusion:AccordionItem.Content>
                    </syncfusion:AccordionItem>
                </DataTemplate>
            </BindableLayout.ItemTemplate>
        </syncfusion:SfAccordion>
    </StackLayout>
</rxui:ReactiveContentPage>

```
```csharp
public partial class MainPage : ReactiveContentPage<ViewModel>
{
    public MainPage(ViewModel viewModel)
    {
        
    }
}

```

STEP 4: View can be connected in one-way dependent manner to the ViewModel through [bindings](https://www.reactiveui.net/docs/handbook/data-binding/). You can set the BindingContext for the SfAccordion in MainPage.cs itself in code behind like below.

```csharp
public partial class MainPage : ReactiveContentPage<ViewModel>
{
    public MainPage(ViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }
}
```

 Download the complete sample from [GitHub](https://github.com/SyncfusionExamples/How-to-bind-ItemSource-using-Reactive-MVVM-in-.net-MAUI-SfAccordion)


## Usage
The application demonstrates:
- Creating a ReactiveUI ViewModel implementing `ReactiveObject`
- Binding an `ObservableCollection` to the SfAccordion `ItemsSource`
- Using `ReactiveContentPage` to connect the ViewModel to the View
- Handling item tap actions using Reactive commands  

When an accordion item is tapped, the application displays contextual information using reactive command bindings.

## Documentation
- **General Syncfusion documentation:**  
  https://help.syncfusion.com/
- **.NET MAUI Introduction:**  
  https://help.syncfusion.com/maui/introduction/overview
- **.NET MAUI Accordion Getting Started:**  
  https://help.syncfusion.com/maui/accordion/getting-started

## Additional Resources
- Syncfusion MAUI Accordion product overview:  
  https://www.syncfusion.com/maui-controls/maui-accordion
- ReactiveUI documentation:  
  https://www.reactiveui.net/docs/

## Troubleshooting
- Ensure ReactiveUI and ReactiveUI.Maui packages are properly installed.
- Verify that `ReactiveContentPage` is used as the base class.
- Rebuild the solution if bindings are not reflected.
- Check output logs for binding or runtime errors.

## Support
For detailed API references and advanced configuration options, refer to the Syncfusion .NET MAUI Accordion documentation links above.  

For additional help, visit:
- Syncfusion Forums  
- Direct‑Trac Support  
- Feedback Portal


**Conclusion:**

I hope you enjoyed learning how to bind itemssource using Reactive MVVM in .NET MAUI Accordion.
You can refer to our [.NET MAUI Accordion](https://www.syncfusion.com/maui-controls/maui-accordion) feature tour page to know about its other groundbreaking feature representations and documentation, and how to quickly get started with configuration specifications.
For current customers, check out our components from the [License and Downloads](https://support.syncfusion.com/create) page. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui/confirm) to check out our other controls.
Please let us know in the comments section if you have any queries or require clarification. You can also contact us through our support [forums](https://www.syncfusion.com/forums/), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfaccordion). We are always happy to assist you!