using JsonApp1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

public class ColorsViewModel : INotifyPropertyChanged
{
    private string colorsmodel;
    private string name;
    private string color;

    public string ColorsModel
    {
        get { return colorsmodel; }
        private set
        {
            colorsmodel = value;
            OnPropertyChanged("ColorsModel");
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            name = value;
            OnPropertyChanged("Name");
        }
    }
    public string Сolor
    {
        get { return color; }
        private set
        {
            color = value;
            OnPropertyChanged("Color");
        }
    }

    public ICommand LoadDataCommand { protected set; get; }

    public ColorsViewModel()
    {
        this.LoadDataCommand = new Command(LoadData);
    }

    private async void LoadData()
    {
        string url = "https://reqres.in/api/products/";

        try
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

            // десериализация ответа в формате json
            var content = await response.Content.ReadAsStringAsync();
            JObject o = JObject.Parse(content);

            var str = o.SelectToken(@"$.data");
            var ColorsInfo = JsonConvert.DeserializeObject<ColorsModel>(str.ToString());

            this.ColorsModel = ColorsInfo.Name;
            this.Name = ColorsInfo.Name;
            this.Сolor = ColorsInfo.PantoneValue;
        }
        catch (Exception ex)
        { }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}

