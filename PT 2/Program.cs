using System;

namespace Perusahaan
{

    public class Karyawan
    {
        public string Nama { get; set; }
        public double Gaji { get; set; }

        public Karyawan(string nama, double gaji)
        {
            Nama = nama;
            Gaji = gaji;
        }

        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja.");
        }

        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama} | Gaji Pokok: Rp{Gaji:N0}");
        }
    }

    public class Tetap : Karyawan
    {
        public double Tunjangan { get; set; }

        public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
        {
            Tunjangan = tunjangan;
        }

        public double HitungGajiTotal()
        {
            return Gaji + Tunjangan;
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama} | Status: Tetap | Gaji Pokok: Rp{Gaji:N0} | Tunjangan: Rp{Tunjangan:N0} | Total Gaji: Rp{HitungGajiTotal():N0}");
        }
    }

    public class Kontrak : Karyawan
    {
        public int Durasi { get; set; }

        public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
        {
            Durasi = durasi;
        }

        public void CekKontrak()
        {
            Console.WriteLine($"Masa kontrak {Nama} tersisa/berdurasi {Durasi} bulan.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama} | Status: Kontrak | Gaji: Rp{Gaji:N0} | Durasi Kontrak: {Durasi} bulan");
        }
    }

    public class Manager : Tetap
    {
        public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public override void Kerja()
        {
            Console.WriteLine($"Manager {Nama} sedang memimpin rapat evaluasi bulanan dan menyusun strategi perusahaan.");
        }

        public void Memimpin()
        {
            Console.WriteLine($"Manager {Nama} sedang memimpin divisi dan mengarahkan tim.");
        }
    }

    public class Staff : Tetap
    {
        public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public override void Kerja()
        {
            Console.WriteLine($"Staff {Nama} sedang menyelesaikan tugas operasional harian.");
        }

        public void KerjakanTugas()
        {
            Console.WriteLine($"Staff {Nama} sedang mengerjakan tugas teknis yang diberikan.");
        }
    }

    public class Magang : Kontrak
    {
        public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public override void Kerja()
        {
            Console.WriteLine($"Anak Magang {Nama} sedang membantu tim proyek sambil mempelajari workflow kerja.");
        }

        public void Belajar()
        {
            Console.WriteLine($"Anak Magang {Nama} sedang mempelajari modul teknologi dan tools baru.");
        }
    }

    public class Freelancer : Kontrak
    {
        public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public override void Kerja()
        {
            Console.WriteLine($"Freelancer {Nama} sedang menyelesaikan deliverable proyek sesuai milestone.");
        }

        public void AmbilProyek()
        {
            Console.WriteLine($"Freelancer {Nama} telah menyetujui dan mengambil proyek freelance baru.");
        }
    }


    public class Perusahaan
    {
        public List<Karyawan> daftarKaryawan { get; set; } = new List<Karyawan>();

        public void TambahKaryawan(Karyawan karyawan)
        {
            daftarKaryawan.Add(karyawan);
            Console.WriteLine($"Karyawan {karyawan.Nama} berhasil ditambahkan ke perusahaan.");
        }

        public void DaftarKaryawan()
        {
            Console.WriteLine("\n=== DAFTAR SELURUH KARYAWAN PERUSAHAAN ===");
            foreach (var k in daftarKaryawan)
            {
                k.InfoKaryawan();
            }
            Console.WriteLine("==========================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Perusahaan ptMajuJaya = new Perusahaan();


            Manager manager1 = new Manager("Relo", 12000000, 3500000);
            Staff staff1 = new Staff("Azhim", 6000000, 1000000);
            Magang magang1 = new Magang("Febri", 2500000, 6);
            Freelancer freelancer1 = new Freelancer("Gesta", 5000000, 3);


            ptMajuJaya.TambahKaryawan(manager1);
            ptMajuJaya.TambahKaryawan(staff1);
            ptMajuJaya.TambahKaryawan(magang1);
            ptMajuJaya.TambahKaryawan(freelancer1);


            ptMajuJaya.DaftarKaryawan();


            Console.WriteLine("=== DEMONSTRASI POLYMORPHISM (Kerja()) ===");
            foreach (Karyawan k in ptMajuJaya.daftarKaryawan)
            {
                k.Kerja();
            }


            Console.WriteLine("\n=== PEMANGGILAN METHOD KHUSUS ===");
            manager1.Memimpin();
            staff1.KerjakanTugas();
            magang1.Belajar();
            freelancer1.AmbilProyek();
            manager1.HitungGajiTotal();
            magang1.CekKontrak();
        }
    }
}