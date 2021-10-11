using System;

namespace Chapter12__1
{
    public class KomisiKaryawan
    {
        public string NamaAwal { get; }
        public string NamaAkhir { get; }
        public string SSN { get; }
        private decimal penjualanKotor; // penjualan kotor mingguan
        private decimal nilaiKomisi; // persentase nilai komisi
        // lima parameter kontruktor
        public KomisiKaryawan(string namaAwal, string namaAkhir, string sSN, decimal penjualanKotor, decimal nilaiKomisi)
        {
            // memanggil implisit ke objek konstruktor di sini
            NamaAwal = namaAwal;
            NamaAkhir = namaAkhir;
            SSN = sSN;
            PenjualanKotor = penjualanKotor; // validasi penjualan kotor
            NilaiKomisi = nilaiKomisi; // validasi nilai komisi
        }
        // atribut yang mendapatkan dan menetapkan komisi penjualan kotor karyawan
        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0) // validasi
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} harus >= 0");
                }
                penjualanKotor = value;
            }
        }
        // atribut yang mendapatkan dan menetapkan tingkat atau nilai komisi karyawan
        public decimal NilaiKomisi
        {
            get
            {
                return nilaiKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1) // validasi
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(NilaiKomisi)} harus > 0 dan < 1");
                }
                nilaiKomisi = value;
            }
        }

        // menghitung pembayaran komisi karyawan
        public virtual decimal Penghasilan() => NilaiKomisi * PenjualanKotor;
        // mengembalikan representasi string dari objek KomisiKaryawan
        public override string ToString() =>
        $"nama karyawan \t: {NamaAwal} {NamaAkhir}\n" + $"ssn \t\t: {SSN}\n" + $"penjualan kotor : {PenjualanKotor:C}\n" + $"nilai komisi \t: {NilaiKomisi:F2}";
    }
    public class KomisiTambahanKaryawan : KomisiKaryawan
    {
        private decimal gajiPokok; // gaji pokok per minggunya

        // enam parameter konstruktor kelas turunan 
        // dengan memanggil ke kelas dasar konstruktor KomisiKaryawan
        public KomisiTambahanKaryawan(string namaAwal, string namaAkhir, string sSN, decimal grossSales, decimal nilaiKomisi, decimal gajiPokok)
: base(namaAwal, namaAkhir, sSN, grossSales, nilaiKomisi)
        {
            GajiPokok = gajiPokok; // validasi gaji pokok
        }
        // atribut get dan set
        // gaji tambahan karyawan
        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if (value < 0) // validasi
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GajiPokok)} harus >= 0");
                }
                gajiPokok = value;
            }
        }
        // calculate earnings
        public override decimal Penghasilan() => GajiPokok + base.Penghasilan();

        // mengembalikan representasi string dari KomisiTambahanKaryawan
        public override string ToString() => $"{base.ToString()}\ngaji pokok \t: {GajiPokok:C}";
    }

    class PolymorphismTest
    {
        static void Main()
        {
            // menetapkan referensi kelas dasar ke variabel kelas dasar
            var komisiKaryawan = new KomisiKaryawan("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

            // menetapkan referensi kelas turunan ke variabel kelas turunan
            var komisiTambahanKaryawan = new KomisiTambahanKaryawan("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

            // mengaktifkan ToString dan Penghasilan pada objek kelas dasar
            // menggunakan variabel kelas dasar
            Console.WriteLine("Komisi Karyawan \n");
            Console.WriteLine(komisiKaryawan.ToString());
            Console.WriteLine($"penghasilan \t: {komisiKaryawan.Penghasilan()}\n");

            // mengaktifkan ToString dan Penghasilan pada objek kelas turunan
            // menggunakan variabel kelas turunan
            Console.WriteLine("Komisi Tambahan Karyawan\n");
            Console.WriteLine(komisiTambahanKaryawan.ToString());
            Console.WriteLine($"penghasilan \t: {komisiTambahanKaryawan.Penghasilan()}\n");

            // mengaktifkan ToString dan Penghasilan pada objek kelas turunan
            // menggunakan variabel kelas dasar
            KomisiKaryawan komisiKaryawan1 = komisiTambahanKaryawan;
            Console.WriteLine("Komisi Tambahan Karyawan dan Penghasilan");
            Console.WriteLine(komisiKaryawan1.ToString());
            Console.WriteLine($"penghasilan \t: {komisiTambahanKaryawan.Penghasilan()}\n");
        }
    }

}
