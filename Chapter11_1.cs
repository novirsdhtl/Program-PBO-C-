using System;

namespace Chapter11_1
{
    public class KomisiKaryawan : Object
    {
        public String NamaAwal { get; }
        public String NamaAkhir { get; }
        public String SSN { get; }
        private decimal penjualanKotor; //penjualan mingguan kotor
        private decimal tarifKomisi; //presentase komisi

        //konstruktor lima parameter
        public KomisiKaryawan(String namaAwal, string namaAkhir, string sSN, decimal penjualanKotor, decimal tarifKomisi)
        {
            // panggilan implisit ke konstruktor objek terjadi di sini
            NamaAwal = namaAwal;
            NamaAkhir = namaAkhir;
            SSN = sSN;
            PenjualanKotor = penjualanKotor; //memvalidasi penjualan kotor
            TarifKomisi = tarifKomisi; //memvalidasi tingkat komisi
        }
        // properti yang mendapatkan dan menetapkan komisi penjualan kotor karyawan
        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0) //memvalidasi
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(penjualanKotor)} harus >= 0");
                }
                penjualanKotor = value;
            }
        }
        // properti yang mendapatkan dan menetapkan tingkat komisi komisi karyawan
        public decimal TarifKomisi
        {
            get
            {
                return tarifKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1) //memvalidasi
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TarifKomisi)} harus > 0 and < 1");
                }
                tarifKomisi = value;
            }
        }
        // hitung komisi gaji pegawai
        public decimal Pendapatan() => tarifKomisi * penjualanKotor;

        // mengembalikan representasi string dari objek CommissionEmployee
        public override string ToString() =>
        $"komisikaryawan \t: {NamaAwal} {NamaAkhir}\n" + $"ssn \t\t: {SSN}\n" + $"penjualan kotor : { penjualanKotor:C}\n" + $"tarif komisi \t: {tarifKomisi:F2}";
    }
    class TesKomisiKaryawan
    {
        static void Main()
        {
            //memberi contoh objek KomisiKaryawan
            var karyawan = new KomisiKaryawan("Sue", "Jones", "222-22-2222", 10000.00M, .06M);
            //tampilkan data Komisi Karyawan
            Console.WriteLine("Informasi karyawan : \n");
            Console.WriteLine($"Nama awal \t: {karyawan.NamaAwal}");
            Console.WriteLine($"Nama akhir \t: {karyawan.NamaAkhir}");
            Console.WriteLine($"SSN \t\t: {karyawan.SSN}");
            Console.WriteLine($"Penjualan kotor : {karyawan.PenjualanKotor:C}");
            Console.WriteLine($"Tarif komisi \t: {karyawan.TarifKomisi:F2}");
            Console.WriteLine($"Pendapatan \t: {karyawan.Pendapatan():C}");

            karyawan.PenjualanKotor = 5000.00M; //menetapkan penjualan kotor
            karyawan.TarifKomisi = .1M; //menetapkan tarif komisi

            Console.WriteLine("\nInformasi karyawan yang diperbarui :\n");
            Console.WriteLine(karyawan);
            Console.WriteLine($"penghasilan \t: {karyawan.Pendapatan():C}");
        }
    }
}
