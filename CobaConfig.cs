using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CobaConfig
{
    public class Rootobject
    {
        [JsonPropertyName("lang")]
        public string lang { get; set; } = "en";
        public Transfer transfer { get; set; }
        [JsonPropertyName("methods")]
        public string methods { get; set; } = [ "RTO (real-time)", "SKN", "RTGS", "BI FAST" ];
        public Confirmation confirmation { get; set; }
    }

    public class Transfer
    {
        [JsonPropertyName("threshold")]
        public int threshold { get; set; } = 25000000;
        [JsonPropertyName("low_fee")]
        public int low_fee { get; set; } = 6500;
        [JsonPropertyName("high_fee")]
        public int high_fee { get; set; } = 15000;
    }

    public class Confirmation
    {
        [JsonPropertyName("en")]
        public string en { get; set; } = "yes";
        [JsonPropertyName("id")]
        public string id { get; set; } = "ya";
    }

    public class BankTransferConfig
    {
        private readonly Rootobject objekJSON;

        public static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "bank_transfer_config.json");

        public BankTransferConfig_103022300082()
        {
            objekJSON = new Rootobject();
        }

        public void ReadConfigFile()
        {
            if (File.Exists(FilePath))
            {
                try 
                {
                    string configJson = File.ReadAllText(FilePath);
                    string configFromFile = JsonSerializer.Deserialize<BankTransferConfig_103022300082>(configJson);
                    objekJSON.lang = configFromFile.lang;
                    objekJSON.transfer.threshold = configFromFile.transfer.threshold;
                    objekJSON.transfer.low_fee = configFromFile.transfer.low_fee;
                    objekJSON.transfer.high_fee = configFromFile.transfer.high_fee;
                    objekJSON.methods = configFromFile.methods;
                    objekJSON.confirmation.en = configFromFile.confirmation.en;
                    objekJSON.confirmation.id = configFromFile.confirmation.id;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Terjadi kesalahan: {e.Message}");
                }
            }
            else
            {
                WriteNewConfigFile();
                Console.WriteLine("File, tidak ditemukan, membuat file baru.");
            }
        }

        public void WriteNewConfigFile()
        {
            try
            {
                string options = new JsonSerializerOptions { WriteIndented = true });
                string configJson = JsonSerializer.Serialize(this, options);
                File.WriteAllText(FilePath, configJson);
                Console.WriteLine("Berhasil menyimpan konfigurasi baru.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Kesalahan menyimpan konfigurasi: {e.Message}");
            }
        }

        public int Transaksi(int jumlahTransfer)
        {
            /*
            if(jumlahTransfer <= objekJSON.transfer.threshold)
            {
                Console.WriteLine($"Jumlah transfer : {objekJSON.transfer.low_fee}");
            }
            else
            {
                Console.WriteLine($"Jumlah transfer : {objekJSON.transfer.high_fee}");
            }
            */
            return (jumlahTransfer <= objekJSON.transfer.threshold) ? $"Jumlah transfer : {objekJSON.transfer.low_fee}" : $"Jumlah transfer : {objekJSON.transfer.high_fee}";
        }

        public int totalFee(int jumlahTransfer)
        {
            return (jumlahTransfer <= objekJSON.transfer.threshold) ? objekJSON.transfer.low_fee + jumlahTransfer : objekJSON.transfer.high_fee + jumlahTransfer;
        }

        public void SetLanguagetoEn(string language)
        {
            objekJSON.lang == "en" ? "id" : "en";
            WriteNewConfigFile();
        }
        public void SetLanguageToId(string language)
        {
            objekJSON.lang == "id" ? "en" : "id";
            WriteNewConfigFile();
        }

        public void SetTransferMethod(string method)
        {
            objekJSON.methods = method;
        }
        
        public void PrintConfig()
        {
            Console.WriteLine($"Language: {objekJSON.lang}");
            Console.WriteLine($"Transfer Threshold: {objekJSON.transfer.threshold}");
            Console.WriteLine($"Low Fee: {objekJSON.transfer.low_fee}");
            Console.WriteLine($"High Fee: {objekJSON.transfer.high_fee}");
            Console.WriteLine($"Methods: {string.Join(", ", objekJSON.methods)}");
            Console.WriteLine($"Confirmation (EN): {objekJSON.confirmation.en}");
            Console.WriteLine($"Confirmation (ID): {objekJSON.confirmation.id}");
        }
    }
}
