using System.Collections.Generic;

namespace swissknife.Services.GameServices.Hangman
{
    public struct HangmanAssets
    {
        public static string[] _frames =
        {
            @"
                     
                    
               
               
               
               

            ",
            @"
                     
                    
               
               
               
               

            =======",
            @"
                     
                    
               
               
               

               |
            =======",
            @"
                     
                    
               
               

               |
               |
            =======",
            @"
                     
                    
               

               |
               |
               |
            =======",
            @"
                     
                    

               |
               |
               |
               |
            =======",
            @"
                

               |      
               |
               |
               |
               |
            =======",
            @"
               
               |      
               |      
               |
               |
               |
               |
            =======",
            @" 
               ________
               |      
               |      
               |
               |
               |
               |
            =======",
            @" 
               ________
               |      |
               |      
               |
               |
               |
               |
            =======",
            @" 
               ________
               |      |
               |      O
               |
               |
               |
               |
            =======",
            @" 
               ________
               |      |
               |      O
               |     /|\
               |
               |
               |
            =======",
            @" 
               ________
               |      |
               |      O
               |     /|\
               |      |
               |
               |
            =======",
            @" 
               ________
               |      |
               |      O
               |     /|\
               |      |
               |     / \
               |
            =======",
        };
        public static Dictionary<string, string[]> _groupedWords = new Dictionary<string, string[]>()
        {
            {
                "Hayvanlar",
                new string[]
                {
                    "kedi", "köpek", "aslan", "kaplan", "zürafa", "fil", "ayı", "balina",
                    "yunus", "penguen", "timsah", "yılan", "kaplumbağa", "tilki", "tavşan",
                    "inek", "keçi", "koyun", "at", "fare", "sincap", "kartal", "baykuş",
                    "serçe", "devekuşu", "panda", "kanguru"
                }
            },
            {
                "Teknoloji",
                new string[]
                {
                    "bilgisayar", "yazılım", "donanım", "internet", "yapayzeka", "robot",
                    "sunucu", "ağ", "uydu", "mikroçip", "veritabanı", "işlemci", "anakart",
                    "bellek", "tarayıcı", "ekran", "modem", "yazıcı", "algoritma", "veri",
                    "drone", "kriptografi", "blokzincir", "bulut", "ağkartı"
                }
            },
            {
                "Ülkeler",
                new string[]
                {
                    "türkiye", "almanya", "fransa", "italya", "ispanya", "portekiz", "yunanistan",
                    "japonya", "çin", "kore", "rusya", "amerika", "kanada", "meksika",
                    "brezilya", "arjantin", "şili", "norveç", "isveç", "finlandiya",
                    "ingiltere", "hollanda", "belçika", "isviçre", "misir", "iran"
                }
            },
            {
                "Genel",
                new string[]
                {
                    "kitap", "masa", "kalem", "okul", "bahçe", "şehir", "araba", "uçak",
                    "telefon", "bilgi", "oyun", "zaman", "rüya", "dağ", "deniz", "göl",
                    "orman", "ışık", "gökyüzü", "bulut", "yağmur", "kar", "rüzgar", "kum",
                    "yıldız", "ay", "güneş"
                }
            },
            {
                "Meyveler",
                new string[]
                {
                    "elma", "armut", "muz", "çilek", "kiraz", "karpuz", "kavun", "erik",
                    "nar", "portakal", "mandalina", "üzüm", "kayısı", "şeftali", "kivi",
                    "incir", "hurma", "ananas", "avokado", "mango", "greyfurt", "yabanmersini"
                }
            },
            {
                "Sebzeler",
                new string[]
                {
                    "domates", "salatalık", "biber", "patlıcan", "kabak", "havuç", "soğan",
                    "sarımsak", "ıspanak", "lahana", "marul", "brokoli", "karnabahar",
                    "bezelye", "mısır", "pancar", "turp", "roka", "enginar"
                }
            },
            {
                "Meslekler",
                new string[]
                {
                    "doktor", "öğretmen", "mühendis", "avukat", "hemşire", "pilot", "aşçı",
                    "yazılımcı", "tasarımcı", "polis", "itfaiyeci", "asker", "marangoz",
                    "terzi", "kuaför", "dişhekimi", "mimar", "arkeolog", "psikolog", "ekonomist"
                }
            },
            {
                "Filmler",
                new string[]
                {
                    "matrix", "inception", "avatar", "gladyatör", "titanic", "dune",
                    "yüzüklerinEfendisi", "starwars", "batman", "superman", "interstellar",
                    "jokers", "terminator", "godfather", "fightclub", "harrypotter", "frozen",
                    "ironman", "thor", "blackpanther"
                }
            },
            {
                "Tarihi Şahsiyetler",
                new string[]
                {
                    "atatürk", "fatih", "yavuz", "kanuni", "napolyon", "einstein", "newton",
                    "galileo", "cleopatra", "cezanne", "davinci", "sokrates", "platon",
                    "aristoteles", "mevlana", "yunusemre", "bismarck", "churchill"
                }
            },
            {
                "Uzay",
                new string[]
                {
                    "gezegen", "güneş", "ay", "yıldız", "galaksi", "samanyolu", "karaDelik",
                    "meteor", "roket", "astronot", "uydu", "teleskop", "evren", "mars",
                    "jüpiter", "neptün", "uranüs", "satürn", "dünya", "ışıkyılı"
                }
            },
            {
                "Renkler",
                new string[]
                {
                    "kırmızı", "mavi", "yeşil", "sarı", "mor", "turuncu", "pembe", "lacivert",
                    "kahverengi", "gri", "siyah", "beyaz", "beij", "bordo", "füme", "altın",
                    "gümüş", "turkuaz", "zümrüt"
                }
            }
        };
    }
}
