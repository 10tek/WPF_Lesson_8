using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CombinedElementsLesson
{
    /// <summary>
    /// Interaction logic for TraderTable.xaml
    /// </summary>
    public partial class TradeTable : UserControl
    {
        private List<Company> companies;

        public TradeTable()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            using (var context = new TraderContext())
            {
                companies = context.Companies.ToList();
                priceHistoryDG.ItemsSource = context.PriceHistories
                    .Where(x => x.CompanyId == companies.FirstOrDefault().Id).ToList();

                companiesComboBox.ItemsSource = companies;
            }
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            var index = companiesComboBox.SelectedIndex;

            using (var context = new TraderContext())
            {
                companies = context.Companies.ToList();
                priceHistoryDG.ItemsSource = context.PriceHistories
                    .Where(x => x.CompanyId == companies[index].Id).ToList();

                companiesComboBox.ItemsSource = companies;
            }
        }
    }
}
