using System;

namespace Chapter11_2
{
    public class KomisiTambahanKaryawan
    {
        public string NamaAwal;
        public string NamaAkhir;
        public string SocialSecurityNumber;
        private decimal penjualanKotor; // penjualan mingguan kotor
        private decimal tingkatKomisi; // persentase komisi
        private decimal gajiPokok; // gaji pokok per minggu

        // konstruktor enam parameter
        public KomisiTambahanKaryawan(string namaAwal, string namaAkhir, string socialSecurityNumber, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
        {
            // panggilan implisit ke konstruktor objek terjadi di sini
            NamaAwal = namaAwal;
            NamaAkhir = namaAkhir;
            SocialSecurityNumber = socialSecurityNumber;
            PenjualanKotor = penjualanKotor; // memvalidasi penjualan kotor
            TingkatKomisi = tingkatKomisi; // memvalidasi tingkat komisi
            GajiPokok = gajiPokok; // memvalidasi gaji pokok
        }
        public void setNamaAwal(string namaAwal)
        {
            NamaAwal = namaAwal;
        }
        public string getNamaAwal()
        {
            return NamaAwal;
        }
        public void setNamaAkhir(string namaAkhir)
        {
            NamaAkhir = namaAkhir;
        }
        public string getNamaAkhir()
        {
            return NamaAkhir;
        }
        public void setSocialSecurityNumber(string socialSecurityNumber)
        {
            SocialSecurityNumber = socialSecurityNumber;
        }
        public string getSocialSecurityNumber()
        {
            return SocialSecurityNumber;
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
                penjualanKotor = (value < 0) ? 0 : value; // memvalidasi
            }
        }
        // properti yang mendapatkan dan menetapkan tingkat komisi komisi karyawan
        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                tingkatKomisi = (value > 0 && value < 1) ? value : 0; // memvalidasi
            }
        }
        // properti yang mendapatkan dan menetapkan KomisiTambahanKaryawan gaji pokok
        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                gajiPokok = (value < 0) ? 0 : value; // memvalidasi
            }
        }
        // menghitung komisi gaji pegawai
        public decimal Pendapatan()
        {
            return gajiPokok + (tingkatKomisi * penjualanKotor);
        }
        // mengembalikan representasi string dari objek KomisiKaryawan
        public override string ToString()
        {
            return string.Format("Nama Awal \t: {0} \nNama Akhir \t: {1} \nSSN \t\t: {2} \nPenjualan Kotor : {3} \nTingkat Komisi \t: {4} \nGaji Pokok \t: {5}", NamaAwal, NamaAkhir, SocialSecurityNumber, penjualanKotor, tingkatKomisi, gajiPokok);
        }
        class Program
        {
            static void Main(string[] args)
            {
                // membuat instance objek KomisiKaryawan
                KomisiTambahanKaryawan karyawan = new KomisiTambahanKaryawan("Bob", "Lewis", "333-33-333", 5000.00M, .04M, 300.00M);
                // menampilkan data KomisiKaryawan
                Console.WriteLine("Informasi karyawan  : \n");
                Console.WriteLine("Nama Awal \t: {0}", karyawan.NamaAwal);
                Console.WriteLine("Nama Akhir \t: {0}", karyawan.NamaAkhir);
                Console.WriteLine("SSN \t\t: {0}", karyawan.SocialSecurityNumber);
                Console.WriteLine("Penjualan Kotor : {0:C}", karyawan.PenjualanKotor);
                Console.WriteLine("Tingkat Komisi \t: {0:F2}", karyawan.TingkatKomisi);
                Console.WriteLine("Gaji Pokok \t: {0:C}", karyawan.GajiPokok);
                Console.WriteLine("Pendapatan \t: {0:C}", karyawan.Pendapatan());

                karyawan.PenjualanKotor = 5000.00M; // menetapkan penjualan kotor
                karyawan.TingkatKomisi = .04M; // menetapkan tingkat  komisi
                karyawan.GajiPokok = 1000.00M; // menetapkan gaji pokok
                Console.WriteLine("\n{0}:\n\n{1}", "Informasi karyawan yang diperbarui ", karyawan);
                Console.WriteLine("Pendapatan \t: {0:C}", karyawan.Pendapatan());
                Console.ReadLine();
            }
        }
    }
}
    

