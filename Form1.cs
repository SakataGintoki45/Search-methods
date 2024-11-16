namespace Search_methods
{
    public partial class Form1 : Form
    {
        List<int> values = new List<int> { 10, 23, 45, 56, 72, 90, 123, 199, 345, 678 };
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchValue.Text, out int searchValue))
            {
                int result = sequentialSearch(searchValue);

                if (result != -1)
                {
                    lblResult.Text = $"Sequential Search: Value found in the index {result}.";
                }
                else
                {
                    lblResult.Text = "Sequential Search: Value not found.";
                }

                values.Sort();

                result = binarySearch(searchValue);

                if (result != -1)
                {
                    lblResult.Text += $"\nBinary Search: Value found in index {result}.";
                }
                else
                {
                    lblResult.Text += "\nBinary Search: Value not found.";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid value to search.");
            }
        }


        private int sequentialSearch(int valor)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == valor)
                {
                    return i; 
                }
            }
            return -1;
        }

        private int binarySearch(int valor)
        {
            int left = 0;
            int right = values.Count - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (values[middle] == valor)
                    return middle;

                if (values[middle] < valor)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1; 
        }

    }
}
