using _06_LinqQueryOperatıon;
using System.Net.Cache;
using System.Runtime.InteropServices;

IList <Personel>personList = new List<Personel> ();
{
    new Personel() { PersonID = 1, PersonName = "JOHN ", Age = 18, city = "Istanbul" };
    new Personel() { PersonID = 2, PersonName = "Steve", Age = 15, city = "Istanbul" };
    new Personel() { PersonID = 3, PersonName = "Steve", Age = 25, city = "Ankara" };
    new Personel() { PersonID = 4, PersonName = "Ram", Age = 20, city = "Ankara" };
    new Personel() { PersonID = 5, PersonName = "Ron", Age = 19, city = "Izmir" };


};

#region Select
//Query Syntax
var slect1 = from p in personList select p;//SELECT * FROM personList
  //Belirli kolonları almak istediğimizde seçmek için aşağıdaki kodu kullanırız
var selectColumn1 = from p in personList select new { p.PersonName, p.city };
//Method syntax
var select2 = personList.ToList();
var selectColumn2 = personList.Select(p => new { p.PersonName, p.city });
#region where
//where belirli bir ölçt ifadesine göre koleksiyonu filtreler ve yeni bir koleksiyon döndürür.
//Kriterle,lamda ifadesi veya func temsilci türü olarak belirtilebilir.


//Query Syntax
var where1 = from p in personList where p.Age > 12 && p.Age < 20 select p;
foreach(var item in where1)
{
    Console.WriteLine($"ID:{item.PersonID} Name:{item.PersonName}");
}
//Method syntax
var where2 = personList.Where(p => p.Age > 12 && p.Age < 20);
foreach (var item in where1)
{
    Console.WriteLine($"ID:{item.PersonID} Name:{item.PersonName}");
}

#region Oreder By

//Query Sytax
//Order By ,bir koleksiyonun  değerinin artan veya azalan olarak sıralar
//select*from personList Order By PersonName asc
//Query Syntax
var orderBy1 = from p in personList orderby p.PersonName ascending select p;//ascending is default
var ordebydesc1 = from p in personList orderby p.PersonName descending select p;

//Method syntax
var orderby2 = personList.OrderBy(p => p.PersonName);
var OrderBYDesc = personList.OrderByDescending(P => P.PersonName);
#region gROUPbY

//Group By,bazı anahtar değerleri temel alarak verilen koleksiyondan bir grup öge döndürür
//select*from personList Group By Age

//Query Syntax
var groupBy1 = from p in personList group p by p.Age;

//Method syntax
var groupBy2 = personList.GroupBy(p => p.Age);

#region Any
//Any Herhangi bir elemanın verilen koşulu sağlayıp sağlamadığını kontrol eder.
//Method syntax
bool any1 = personList.Any(p => p.city == "Istanbul");

#region Contains
//Contains ,koleksiyonunda belirtilen bir ögenin var olup olmadığını kontrol eder ve bir bool döndürür
//Method syntax
Personel prs = new Personel() { PersonID = 3, PersonName = "Bill", };
bool contains=personList.Contains(prs);

#region Average
//Average ,sayısal verilerin ortalamasını döndürür

//Method syntax
var avrg = personList.Average(p => p.Age);

//Sum ,sayısal verilerin toplamını döndürür
//method syntax 
var sum = personList.Sum(p => p.Age);

#region Take
//Take ,ilk ögeden başlayarak belirtilen sayıda öge dödürrü
//TakeWhile ,belirtilen koşuldoğru olana kadar ögelri dödürür.

var take = personList.Take(3);
var takeWhile = personList.TakeWhile(p => p.city == "Istanbul");
foreach(var item in takeWhile)
{
    Console.WriteLine(item.PersonName);
}
//skip ilk ögeden başlayarak belirtilen sayıda ögeyi atlar ve kalanları döndürürü
//SkpWhile ,belirtilen koşul doğru olana kadar koleksiyondaki ögeleri atlar

//Method sntax
var skip = personList.Skip(3);
foreach(var item in skip)
{
    Console.WriteLine($"{item.PersonName}");
}
#region Firt FirstOrDefault

//First bir koleksiyonun il ögesinin veya bir koşulu sağlayan lk ögeyi döndürür
//FirstOrDefault bir koleksiyonon ilk ögesinin veya bir koşulu sağlyan ilk ögeyi dndürrü
//indeks aralığında bir değer döndürür
//Method Syntax
var first1 = personList.First();
var first2 = personList.First(p => p.PersonName == "Steve");

var first3 = personList.FirstOrDefault();
var first4 = personList.FirstOrDefault(p => p.PersonName == "Steve");

#region lASoRdEFAULT
//Bir koleksiyondaki son ögeyi döndürür.Hiç Bir öge bulamazsa istisa tara.
//LastOrDefault Bir koşulu sağlayan son ögeyi dödürürn öge bulamazsa varsayılan bir değer döndürür.
//Method syntax

var Last1 = personList.Last();
var Last2 = personList.Last(P => P.PersonName == "Steve");

var last3 = personList.LastOrDefault();
var Last4 = personList.LastOrDefault(p => p.PersonName == "Steve");


#region Single

//Singel bir koleksiyondaki tek ögeyi veya bir koşulu sağlayan tek ögeyi döndürür.
var single1 = personList.Single();
var single2 = personList.Single(p => p.PersonName == "Steve");

var single3 = personList.SingleOrDefault();
var single4 = personList.SingleOrDefault(p => p.PersonName == "Steve");

#region Joın

//joın operatörü inner collection ve outher collectın olmak üzere iki collectıon üzerinden çalışır
//Beliritlen ifadeyi karşılayan her iki colectıondanda ögeler içeren yeni bir collectıon döndürür.

IList<StandardForJoın> standardList = new List<StandardForJoın>()
{
    new StandardForJoın(){StandardID=1,StandardName="Steve" };
new StandardForJoın() { StandardID = 1, StandardName = "Steve" };
new StandardForJoın() { StandardID = 1, StandardName = "Steve" };

};

//Method SYNTAX
var ınnerjoın1=studentList.joın()//outhor collectıon
    standardList//ınner Collectıon
    student=>StudentForJoın.StandardID//OUTHER KEY SELECTOR
    standard=>standardList.StandardID//ınner key selector

    (standard,student)=>new
             {
                    studentName=student.Name,
                    standardName=standard.Name,
             }