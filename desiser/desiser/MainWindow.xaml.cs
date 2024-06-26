using System.Windows;
using SerializationLibrary;

namespace SerializationDemoApp
{
    public partial class MainWindow : Window
    {
        private readonly SerializationHelper _serializer = new SerializationHelper();
        private readonly string _binaryFilePath = "data.bin";
        private readonly string _xmlFilePath = "data.xml";
        private readonly string _jsonFilePath = "data.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeToBinary_Click(object sender, RoutedEventArgs e)
        {
            var data = new SampleData { Id = 1, Name = "Test Binary" };
            _serializer.SerializeToBinary(data, _binaryFilePath);
            OutputTextBox.Text = "Serialized to Binary";
        }

        private void DeserializeFromBinary_Click(object sender, RoutedEventArgs e)
        {
            var data = _serializer.DeserializeFromBinary<SampleData>(_binaryFilePath);
            OutputTextBox.Text = $"Deserialized from Binary: {data.Name}";
        }

        private void SerializeToXml_Click(object sender, RoutedEventArgs e)
        {
            var data = new SampleData { Id = 2, Name = "Test XML" };
            _serializer.SerializeToXml(data, _xmlFilePath);
            OutputTextBox.Text = "Serialized to XML";
        }

        private void DeserializeFromXml_Click(object sender, RoutedEventArgs e)
        {
            var data = _serializer.DeserializeFromXml<SampleData>(_xmlFilePath);
            OutputTextBox.Text = $"Deserialized from XML: {data.Name}";
        }

        private void SerializeToJson_Click(object sender, RoutedEventArgs e)
        {
            var data = new SampleData { Id = 3, Name = "Test JSON" };
            _serializer.SerializeToJson(data, _jsonFilePath);
            OutputTextBox.Text = "Serialized to JSON";
        }

        private void DeserializeFromJson_Click(object sender, RoutedEventArgs e)
        {
            var data = _serializer.DeserializeFromJson<SampleData>(_jsonFilePath);
            OutputTextBox.Text = $"Deserialized from JSON: {data.Name}";
        }
    }
    [Serializable]
    public class SampleData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}