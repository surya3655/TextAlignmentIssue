using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FrameWorkIssue
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class CustomView : HorizontalStackLayout
    {

        public Entry Entry { get; set; }
      
        public static readonly BindableProperty VerticalTextAlignmentProperty =
           BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(CustomView), TextAlignment.End, BindingMode.Default, null, OnVerticalTextAlignmentPropertyChanged);

        private static void OnVerticalTextAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CustomView view)
            {
                if (view != null)
                {
                    view.Entry.VerticalTextAlignment = view.VerticalTextAlignment;
                }
            }
        }

        public TextAlignment VerticalTextAlignment
        {
            get { return (TextAlignment)GetValue(VerticalTextAlignmentProperty); }
            set { SetValue(VerticalTextAlignmentProperty, value); }
        }

        public CustomView()
        {
            Entry = new Entry();
            Entry.Margin = new Thickness(0, 0, 35, 0);
            Entry.VerticalTextAlignment = TextAlignment.End;
            this.Add(Entry);
        }


    }

    public class TextAlignmentViewModel : INotifyPropertyChanged
    {
        private TextAlignment _verticalTextAlignment;
       
        public ObservableCollection<TextAlignment> VerticalTextAlignmentOptions { get; } = new()
        {
            TextAlignment.Start,
            TextAlignment.End,
            TextAlignment.Center
        };
       
        public TextAlignmentViewModel()
        {
          
        }

        public TextAlignment VerticalTextAlignment
        {
            get => _verticalTextAlignment;
            set
            {
                if (_verticalTextAlignment != value)
                {
                    _verticalTextAlignment = value;
                    OnPropertyChanged();
                }
            }
        }

       
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
