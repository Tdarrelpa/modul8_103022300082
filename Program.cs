// See https://aka.ms/new-console-template for more information
using CobaConfig;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please select the language/ Silahkan pilih bahasa: ");
        string languageOptions = Console.ReadLine();
        BankTransferConfig transfer = new BankTransferConfig();

        if (languageOptions == "en")
        {
            transfer.SetLanguagetoEn(languageOptions);
        }
        else if (languageOptions == "id")
        {
            transfer.SetLanguageToId(languageOptions);
        }
        else
        {
            Console.WriteLine("Invalid language option.");
        }

        if (languageOptions == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else if (languageOptions == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }
        else
        {
            Console.WriteLine("Invalid language option.");
        }

        int amount = Convert.ToInt32(Console.ReadLine());

        if (languageOptions == "en")
        {
            Console.WriteLine($"Transfer fee = {transfer.Transaksi(amount)}");
            Console.WriteLine($"Total amount = {transfer.totalFee(amount)}");
        }
        else if (languageOptions == "id")
        {
            Console.WriteLine($"Biaya transfer = {transfer.Transaksi(amount)}");
            Console.WriteLine($"Total biaya = {transfer.totalFee(750000)}");
        }
        else
        {
            Console.WriteLine("Invalid language option.");
        }

        if (languageOptions == "en")
        {
            Console.WriteLine("Select transfer method: ");
        }
        else if (languageOptions == "id")
        {
            Console.WriteLine("“Pilih metode transfer: ");
        }
        else
        {
            Console.WriteLine("Invalid language option.");
        }

        int method = Convert.ToInt32(Console.ReadLine());
        switch (method)
        {
            case 1:
                transfer.SetTransferMethod("RTO");
                break;
            case 2:
                transfer.SetTransferMethod("SKN");
                break;
            case 3:
                transfer.SetTransferMethod("RTGS");
                break;
            case 4:
                transfer.SetTransferMethod("BI FAST");
                break;
            default:
                Console.WriteLine("Invalid transfer method.");
                break;
        }
        if (languageOptions == "en")
        {
            Console.WriteLine($"Please type to confirm transaction: ");
        }
        else if (languageOptions == "id")
        {
            Console.WriteLine($"Ketik untuk mengkonfirmasi transaksi");
        }
        else
        {
            Console.WriteLine("Invalid language option.");
        }

        string confirmation = Console.ReadLine();
        if (confirmation == "yes" || confirmation == "ya")
        {
            if (languageOptions == "en")
            {
                Console.WriteLine("The transfer is completed.");
            }
            else if (languageOptions == "id")
            {
                Console.WriteLine("Proses transfer berhasil.");
            }
            else
            {
                Console.WriteLine("Invalid language option.");
            }
        }
        else
        {
            if (languageOptions == "en")
            {
                Console.WriteLine("Transfer is cancelled.");
            }
            else if (languageOptions == "id")
            {
                Console.WriteLine("Transfer dibatalkan.");
            }
            else
            {
                Console.WriteLine("Invalid language option.");
            }
        }
    }
}
