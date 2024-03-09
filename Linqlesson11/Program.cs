using Microsoft.Graph;
using Microsoft.Graph.Models;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

using System;
using System.Collections.Generic;
using System.Linq;
using Linqlesson11.Model;

List<Debtor> debtors = new List<Debtor> {
            new Debtor("Shirley T. Qualls", DateTime.Parse("March 30, 1932"), "530-662-7732", "ShirleyTQualls@teleworm.us", "3565 Eagles Nest Drive Woodland, CA 95695", 2414),
            new Debtor("Danielle W. Grier", DateTime.Parse("October 18, 1953"), "321-473-4178", "DanielleWGrier@rhyta.com", "1973 Stoneybrook Road Maitland, FL 32751", 3599),
            new Debtor("Connie W. Lemire", DateTime.Parse("June 18, 1963"), "828-321-3751", "ConnieWLemire@rhyta.com", "2432 Hannah Street Andrews, NC 28901", 1219),
            new Debtor("Coy K. Adams", DateTime.Parse("March 1, 1976"), "410-347-1307", "CoyKAdams@dayrep.com", "2411 Blue Spruce Lane Baltimore, MD 21202", 3784),
            new Debtor("Bernice J. Miles", DateTime.Parse("June 1, 1988"), "912-307-6797", "BerniceJMiles@armyspy.com", "4971 Austin Avenue Savannah, GA 31401", 4060),
            new Debtor("Bob L. Zambrano", DateTime.Parse("February 28, 1990"), "706-446-1649", "BobLZambrano@armyspy.com", "2031 Limer Street Augusta, GA 30901", 6628),
            new Debtor("Adam D. Bartlett", DateTime.Parse("May 6, 1950"), "650-693-1758", "AdamDBartlett@rhyta.com", "2737 Rardin Drive San Jose, CA 95110", 5412),
            new Debtor("Pablo M. Skinner", DateTime.Parse("August 26, 1936"), "630-391-2034", "PabloMSkinner@armyspy.com", "16 Fraggle Drive Hickory Hills, IL 60457", 11097),
            new Debtor("Dorothy J. Brown", DateTime.Parse("July 9, 1971"), "270-456-3288", "DorothyJBrown@rhyta.com", "699 Harper Street Louisville, KY 40202", 7956),
            new Debtor("Larry A. Miracle", DateTime.Parse("May 22, 1998"), "301-621-3318", "LarryAMiracle@jourrapide.com", "2940 Adams Avenue Columbia, MD 21044", 7150),
            new Debtor("Donna B. Maynard", DateTime.Parse("January 26, 1944"), "520-297-0575", "DonnaBMaynard@teleworm.us", "4821 Elk Rd Little Tucson, AZ 85704", 2910),
            new Debtor("Jessica J. Stoops", DateTime.Parse("April 22, 1989"), "360-366-8101", "JessicaJStoops@dayrep.com", "2527 Terra Street Custer, WA 98240", 11805),
            new Debtor("Audry M. Styles", DateTime.Parse("February 7, 1937"), "978-773-4802", "AudryMStyles@jourrapide.com", "151 Christie Way Marlboro, MA 01752", 1001),
            new Debtor("Violet R. Anguiano", DateTime.Parse("November 4, 1958"), "585-340-7888", "VioletRAnguiano@dayrep.com", "1460 Walt Nuzum Farm Road Rochester, NY 14620", 9128),
            new Debtor("Charles P. Segundo", DateTime.Parse("October 21, 1970"), "415-367-3341", "CharlesPSegundo@dayrep.com", "1824 Roosevelt Street Fremont, CA 94539", 5648),
            new Debtor("Paul H. Sturtz", DateTime.Parse("September 15, 1944"), "336-376-1732", "PaulHSturtz@dayrep.com", "759 Havanna Street Saxapahaw, NC 27340", 10437),
            new Debtor("Doris B. King", DateTime.Parse("October 10, 1978"), "205-231-8973", "DorisBKing@rhyta.com", "3172 Bedford Street Birmingham, AL 35203", 7230),
            new Debtor("Deanna J. Donofrio", DateTime.Parse("April 16, 1983"), "952-842-7576", "DeannaJDonofrio@rhyta.com", "1972 Orchard Street Bloomington, MN 55437", 515),
            new Debtor("Martin S. Malinowski", DateTime.Parse("January 17, 1992"), "765-599-3523", "MartinSMalinowski@dayrep.com", "3749 Capitol Avenue New Castle, IN 47362", 1816),
            new Debtor("Melissa R. Arner", DateTime.Parse("May 24, 1974"), "530-508-7328", "MelissaRArner@armyspy.com", "922 Hill Croft Farm Road Sacramento, CA 95814", 5037),
            new Debtor("Kelly G. Hoffman", DateTime.Parse("September 22, 1969"), "505-876-8935", "KellyGHoffman@armyspy.com", "4738 Chapmans Lane Grants, NM 87020", 7755),
            new Debtor("Doyle B. Short", DateTime.Parse("June 15, 1986"), "989-221-4363", "DoyleBShort@teleworm.us", "124 Wood Street Saginaw, MI 48607", 11657),
            new Debtor("Lorrie R. Gilmore", DateTime.Parse("December 23, 1960"), "724-306-7138", "LorrieRGilmore@teleworm.us", "74 Pine Street Pittsburgh, PA 15222", 9693),
            new Debtor("Lionel A. Cook", DateTime.Parse("April 16, 1972"), "201-627-5962", "LionelACook@jourrapide.com", "29 Goldleaf Lane Red Bank, NJ 07701", 2712),
            new Debtor("Charlene C. Burke", DateTime.Parse("January 18, 1990"), "484-334-9729", "CharleneCBurke@armyspy.com", "4686 Renwick Drive Philadelphia, PA 19108", 4016),
            new Debtor("Tommy M. Patton", DateTime.Parse("June 30, 1981"), "774-571-6481", "TommyMPatton@rhyta.com", "748 Rockford Road Westborough, MA 01581", 349),
            new Debtor("Kristin S. Bloomer", DateTime.Parse("June 16, 1944"), "443-652-0734", "KristinSBloomer@dayrep.com", "15 Hewes Avenue Towson, MD 21204", 9824),
            new Debtor("Daniel K. James", DateTime.Parse("November 10, 1997"), "801-407-4693", "DanielKJames@rhyta.com", "3052 Walton Street Salt Lake City, UT 84104", 8215),
            new Debtor("Paula D. Henry", DateTime.Parse("September 6, 1976"), "618-378-5307", "PaulaDHenry@rhyta.com", "3575 Eagle Street Norris City, IL 62869", 5766),
            new Debtor("Donna C. Sandoval", DateTime.Parse("December 13, 1947"), "540-482-5463", "DonnaCSandoval@rhyta.com", "675 Jehovah Drive Martinsville, VA 24112", 8363),
            new Debtor("Robert T. Taylor", DateTime.Parse("August 17, 1932"), "270-596-6442", "RobertTTaylor@armyspy.com", "2812 Rowes Lane Paducah, KY 42001", 7785),
            new Debtor("Donna W. Alamo", DateTime.Parse("December 9, 1948"), "978-778-2533", "DonnaWAlamo@teleworm.us", "4367 Christie Way Marlboro, MA 01752", 10030),
            new Debtor("Amy R. Parmer", DateTime.Parse("May 19, 1995"), "480-883-4934", "AmyRParmer@armyspy.com", "85 Elmwood Avenue Chandler, AZ 85249", 5347),
            new Debtor("Newton K. Evans", DateTime.Parse("October 8, 1986"), "303-207-9084", "NewtonKEvans@rhyta.com", "3552 Columbia Road Greenwood Village, CO 80111", 9838),
            new Debtor("Kathleen C. Chaney", DateTime.Parse("January 5, 1949"), "605-245-3513", "KathleenCChaney@rhyta.com", "316 Elsie Drive Fort Thompson, SD 57339", 1672),
            new Debtor("Manuel C. Johnson", DateTime.Parse("February 23, 1957"), "606-247-2659", "ManuelCJohnson@jourrapide.com", "4146 May Street Sharpsburg, KY 40374", 9195),
            new Debtor("Carla A. Creagh", DateTime.Parse("November 21, 1988"), "614-307-8974", "CarlaACreagh@dayrep.com", "3106 Bates Brothers Road Columbus, OH 43215", 11271),
            new Debtor("Norma M. New", DateTime.Parse("May 18, 1988"), "857-492-8703", "NormaMNew@jourrapide.com", "965 Metz Lane Woburn, MA 01801", 9761),
            new Debtor("Roy D. Green", DateTime.Parse("January 27, 1983"), "308-340-5981", "RoyDGreen@jourrapide.com", "401 Romrog Way Grand Island, NE 68801", 10771),
            new Debtor("Cristy J. Jensen", DateTime.Parse("November 2, 1935"), "440-626-9550", "CristyJJensen@jourrapide.com", "2177 Harley Vincent Drive Cleveland, OH 44113", 5205),
            new Debtor("Nancy J. Fergerson", DateTime.Parse("June 10, 1993"), "219-987-8498", "NancyJFergerson@dayrep.com", "3584 Jadewood Drive Demotte, IN 46310", 1276),
            new Debtor("Dave N. Rodriguez", DateTime.Parse("January 21, 1938"), "214-540-2499", "DaveNRodriguez@rhyta.com", "1890 Poco Mas Drive Dallas, TX 75247", 9132),
            new Debtor("James E. Denning", DateTime.Parse("May 4, 1988"), "504-289-8640", "JamesEDenning@jourrapide.com", "1444 Rose Avenue Metairie, LA 70001", 8176),
            new Debtor("Richard M. Thomas", DateTime.Parse("February 13, 1972"), "510-735-3359", "RichardMThomas@jourrapide.com", "4454 Green Avenue Oakland, CA 94609", 7875),
            new Debtor("Lakisha R. Forrest", DateTime.Parse("December 1, 1973"), "334-830-1181", "LakishaRForrest@armyspy.com", "3121 Quarry Drive Montgomery, AL 36117", 3088),
            new Debtor("Pamela H. Beauchamp", DateTime.Parse("November 20, 1959"), "801-559-6347", "PamelaHBeauchamp@jourrapide.com", "3239 Tori Lane Salt Lake City, UT 84104", 6588)
        };


//2
/*
var t2 =debtors.Where((d) =>  d.Email.Contains( "rhyta.com") || d.Email.Contains(  "dayrep.com")).ToList();
t2.ForEach((d1) => Console.WriteLine(d1.FullName));*/

//3) Yashi 26 - dan 36 - ya qeder olan borclulari cixartmag
/*var t3 = debtors.Where((d) =>   d.BirthDay.Year > 1988 ).ToList();

t3.ForEach((d) => Console.WriteLine(d.FullName ));
*/

//4
/*
var t4 = debtors.Where((d) => d.Debt<5000).ToList();
Console.ForegroundColor = ConsoleColor.Red;
t4.ForEach((d) => Console.WriteLine(d.FullName + " Debt => "+ d.Debt));
Console.ForegroundColor = ConsoleColor.White;
*/



//5
/*

var t5 = debtors.Where((d) => d.FullName.Length > 18 &&( d.Phone.Contains("77")  || d.Phone.Contains("7")|| d.Phone.StartsWith("7")) ).ToList();
Console.ForegroundColor = ConsoleColor.Cyan;
t5.ForEach((d) => Console.WriteLine(d.FullName ));
Console.ForegroundColor = ConsoleColor.White;
*/


//7) Qishda anadan olan borclulari cixardmaq
/*
var t7 = debtors.Where(t => t.BirthDay.Month >= 1 && t.BirthDay.Month <= 3).ToList();

t7.ForEach(t => Console.WriteLine(t.FullName));*/


//8) Borcu, umumi borclarin orta borcunnan cox olan borclulari cixarmaq ve evvel familyaya gore sonra ise meblegin azalmagina gore sortirovka etmek
/*

Console.ForegroundColor= ConsoleColor.Green;
var t8 = debtors.Where(d => d.Debt > debtors.Average(d => d.Debt)).ToList();
t8.ForEach(d =>Console.WriteLine(d));
Console.WriteLine();
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.White;

Console.ForegroundColor = ConsoleColor.Red;

var t9 = debtors.OrderBy(d => d.FullName).ToList();
t9.ForEach(d => Console.WriteLine(d.FullName));
Console.WriteLine();
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.White;

Console.ForegroundColor = ConsoleColor.Cyan;

var t10 = debtors.OrderByDescending(d => d.Debt).ToList();
t10.ForEach(d => Console.WriteLine(d.FullName + " "+ d.Debt ));

Console.ForegroundColor = ConsoleColor.White;
*/



//9) Telefon nomresinde 8 olmayan borclularin yalniz familyasin, yashin ve umumi borcun meblegin cixarmaq

//var t9 = debtors.Where(d => !d.Phone.Contains("8")).ToList();
//foreach (var item in t9)
//{
//    Console.WriteLine(item.FullName + "  -age " + (2024 - item.BirthDay.Year) + "   -Debt  " + item.Debt);
//}

/*
11)Adinda ve familyasinda hec olmasa 3 eyni herf olan borclularin siyahisin cixarmaq ve onlari elifba sirasina gore sortirovka elemek
 */

/*
var t11 = debtors.Where(d => d.FullName.GroupBy(c => c).Any(g => g.Count() == 3)).OrderBy(d=> d.FullName).ToList();

t11.ForEach(t => Console.WriteLine(t));*/



//13)borclulardan en coxu hansi ilde dogulubsa hemin ili cixartmaq

/*
var date = debtors.GroupBy(d => d.BirthDay.Year).OrderByDescending(g => g.Count()).First().Key;
//burda ilk once groub ile ile gore quruplasdirrir
//dha sonraaa order ile  grupu saya gore sort edr ve ilk in key in alruq
                         
Console.WriteLine(date);*/



//14)Borcu en boyuk olan 5 borclunun siyahisini cixartmaq
/*
var tt = debtors.OrderByDescending(d => d.Debt).Take(5).ToList();

tt.ForEach(tt => Console.WriteLine(tt));
*/

//15)Butun borcu olanlarin borcunu cemleyib umumi borcu cixartmaq
/*var deb = debtors.Sum(d => d.Debt);

Console.WriteLine(deb);*/


//16)2ci dunya muharibesin gormush borclularin siyahisi cixartmaq
/*
var t = debtors.Where(d => (2024 - d.BirthDay.Year) > 82).ToList();
foreach (var item in t)
{
    Console.WriteLine(item);
}*/

//18)Nomresinde tekrar reqemler olmayan borclularin ve onlarin borcunun meblegin cixartmaq
//sual


//19)Tesevvur edek ki,butun borclari olanlar bugunden etibaren her ay 500 azn pul odeyecekler.Oz ad gunune kimi borcun oduyub qurtara bilenlerin siyahisin cixartmaq


var debts = debtors.Where(d =>
{
    int month = Math.Abs(DateTime.Now.Month - d.BirthDay.Month);
    int debt = 500 * month; 
    return debt>= d.Debt;
}).ToList();

debts.ForEach(a =>
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(a.ToString());
    Console.ForegroundColor = ConsoleColor.White;
});
/*





20)Adindaki ve familyasindaki herflerden "smile" sozunu yaza bileceyimiz borclularin siyahisini cixartmaq
*/





/*
//Linq den gelen methodlar 2 yere n]bolnur
Ienumerable = >  Datani Memory de yigir ve sorgunu memory uzernde edir
Yeni butun melumati ramda edir her seyi
Iqueryable => Sorgunu SQL Query e cevrir ve databazada icra edir
bu ise sqlde is gorur ve rami az yukleyr


List<int> a = Gett().ToList();
a.ForEach(num => Console.WriteLine(num+1 + "\n"));
//yield return 
IEnumerable<int> Gett()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;

}*/




/*
 
var t6 = debtors.First(t => t.Debt > 5000);//bununla axtaridumiz serte en uygun gelen ilk elementi tapa bilerik
Console.WriteLine(t6);


var t6 = debtors.OrderBy(num => num.Debt > 8000).LastOrDefault();//bu methodla biz aldiqimiz bir listin son
                                                                 //elementin elde ede bilerik
Console.WriteLine(t6);


var t6 = debtors.OrderBy((d) => d.Debt).ToList(); // bize sort edmek imkani verir
t6.ForEach((a) => Console.WriteLine(a.Debt));

 
 

var nums = new List<int>() { 1,11,2,3,4,22,22,11,33,22,33,44,22,445,55,5,55,5}; 
//bu method bize bir list daxilinde tekrarlanan ededleri silib yeni bir list qaytarir
var numsDistinct = nums.Distinct();
foreach (var item in numsDistinct)
{
    Console.WriteLine(item);
}
 
 */




/*
var t6 = debtors.Select(t => t.Debt).ToList(); //var olan bir kolleksinin icinden isdedymzi secmeye imkan verir
t6.ForEach(t => Console.WriteLine(t));


var tt = debtors.OrderByDescending(d => d.Debt).Take(5).ToList(); 
//ilk once borc azalma sirasna gore duzduk ve sonra Take ile isdedymz qedern secdk

tt.ForEach(tt => Console.WriteLine(tt));





var deb = debtors.Sum(d => d.Debt);

Console.WriteLine(deb); // cemlemek ucun sum methodu

var lista = new List<List<int>>()
{
    new List<int>(){112,434,3432,2,3},
    new List<int>(){13,234,3432,2,3},
    new List<int>(){11,343,343,2,3},


};



var result = lista.Select(lista => new
{
    Count = lista.Count(),
    Average = lista.Average(),
}).OrderByDescending(counta => counta.Average).Select(counta => $"Count is {counta.Count}" +
$"Average is {counta.Average}"
).ToList();

result.ForEach(t => Console.WriteLine(t));

*/


/*

List<int> Nums = new List<int>() { 234,543,23,234,543,2345,50,12,54,-23};   
List<int> onlyp = Nums.Where(i => i  %2==0).OrderBy(num => num-30).ToList();//sort edmek
Console.WriteLine(Nums.Contains(10));

//onlyp.ForEach(num => Console.Write(num + " "));

Console.WriteLine(Nums.Any(num => num < 0));//biri bele odese True
var n = Nums.Count(num => num < -5);

*/
//Console.Write(Nums.All(num => num < 0));//biri bele odemese Falsse



/*
B b = new B();
b[1] = new string("a");


class B  {
    public List<string> list { get; set; } = new List<string>(); 
    public string this[int i]{
        get { return list[i]; }
        set { list[i] = value; }    
    }
     
}*/