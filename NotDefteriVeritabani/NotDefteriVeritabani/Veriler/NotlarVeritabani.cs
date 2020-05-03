using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NotDefteriVeritabani.VeriModelleri;
using SQLite;

namespace NotDefteriVeritabani.Veriler
{
    public class NotlarVeritabani
    {
        SQLiteAsyncConnection veritabani;

        public NotlarVeritabani(string dosyaYolu)
        {
            veritabani = new SQLiteAsyncConnection(dosyaYolu);
            veritabani.CreateTableAsync<Notlar>().Wait();
        }

        public async Task<int> YeniNotEkle(Notlar not)
        {
            
            int sonuc = await veritabani.InsertAsync(not);
            return sonuc;
        }

        public async Task<List<Notlar>> NotlariListele()
        {
            return await veritabani.Table<Notlar>().ToListAsync();
        }

        public async Task<int> NotSil(Notlar not)
        {
            return await veritabani.DeleteAsync(not);            
        }

        public async Task<int> NotGuncelle(Notlar not)
        {
            
            return await veritabani.UpdateAsync(not);
        }

        public async Task<Notlar> IdyeGoreNotGetir(int id)
        {
            var not = from u in veritabani.Table<Notlar>()
                      where u.ID == id
                      select u;
            return  await not.FirstOrDefaultAsync();
        }
    }
}
