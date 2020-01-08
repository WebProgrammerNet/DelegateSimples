using System;

namespace DelegateSimplesForStartUp
{
    class Program
    {
        public delegate void DelegateTest(string str);
        public delegate void Info(string name, int age);

        static void Main(string[] args)
        {
            #region Delegate Giris
            //1-ci variant
            string str = "Salam Men Test Metoduyam1";
            //Test(str,Test1);

            //-------------------------------------------

            //2-ci variant
            string str1 = "Salam Men Test Metoduyam1";
            DelegateTest delegateTest1 = new DelegateTest(Test1);
            delegateTest1 += Test2;
            //delegateTest1(str1);// Goster

            //3-cu variant
            string str2 = "Salam Men Test Metoduyam2";
            DelegateTest delegateTest2 = Test1;
            delegateTest2 += Test2;
            //delegateTest2(str2);// Goster

            //4-cu variant
            string str3 = "Salam Men Test Metoduyam3";
            DelegateTest delegateTest3 = Test1;
            delegateTest3 += delegate (string options)//Anonim
            {
                Console.WriteLine(options);
            };
            delegateTest3 += Test2;
            delegateTest3 += Test3;
            //delegateTest3(str3);// Goster
            //Biz 3-cu variantda 4 Methodu(Test1, Test2,Test3, Anonim) bir Parametr gondermekle ise saldiq.

            //4-cu variant
            string str4 = "Salam Men Test Metoduyam4";
            delegateTest3 = options =>//Anonim
            {
                Console.WriteLine(options);
            };
            delegateTest3 += Test1;
            delegateTest3 += Test2;
            //delegateTest3(str4);// Goster
            //Biz 4-cu variantda 3 Methodu(Test1, Test2, Anonim) bir Parametr gondermekle ise saldiq.

            string str5 = "Salam Men Test Metoduyam5";
            DelegateTest delegateTest5 = new DelegateTest(options => {
                Console.WriteLine(options);
            });
            delegateTest5 += Test1;
            delegateTest5 += Test2;
            delegateTest5 += Test3;
            delegateTest5 -= Test3;
            //delegateTest5(str5);// Goster
            //Biz 5-cu variantda 3 Methodu(Anonim, Test1, Test2) bir Parametr gondermekle ise saldiq.
            //Test3 Metodunu ise evvel elaave eledik sonra ise onu sildik
            #endregion 
            #region LambaExpression 2 parametrde Yazilisi Lesson2
            Info info = (name, age) =>
            {
                Console.WriteLine("Person name is: {0} and age is: {1}", name, age);
            };
            //info("Tamilla",25);//Goster
            #endregion
            #region Action(Delegate)
            Action<string,int> infoacction = (name,age) => {
                Console.WriteLine("Person name is:{0} and age is{1}", name, age);
            };
            infoacction += ShortInfo4;
            infoacction += ShortInfo5;
            infoacction -= ShortInfo5;
            //infoacction("Dima", 50);//Goster
            #endregion
            #region Func(Delegate)
            Func<string,int,string> infoFunc = (name, age) =>
            {
                string str7 = $"Person name is:{name} and age is{age} Anonim";
                return str7;
            };
            infoFunc += ShortInfo6;
            infoFunc += ShortInfo7;
            //Console.WriteLine(infoFunc("Shasenem", 20));//Goster
            //Void tip delegate-lardan basqa biz += yazdiqada hemise sonuncunun deyerini qaytarir
            #endregion
        }


        #region delegate Nedir?
        //Salam Dostlar Bu gun Delegate ne demekdir size izah etmeye calisacam.
        //Bizim bir Test adli static void metodumuz var ve biz bu metodun icerisinde string qebul edek.
        //ve  uzatmadan hemin stringi ConsoleWriteline() yazdiraq.
        //SUAL? Biz mu metodun icerisinde PARAMETR  kimi Test metodu ile eyni Signature-ye malik bir metod qebul ede blerik?
        // Cavab : Beli Nece ? Delegate 

        //Action ozu bir delegate-dir.
        //Sadece bizi  public delegate void Info(string name, int age); yazmaqdan azad edir.
        //Bildiyimiz kimi Metodlar 2 yere bolunur 
        //1-cisi Cavab qaytarmayan sadece bir isi goren return olmaya : void Metodlar
        //2-cisi Bize bir deyer qaytaran mueyyen bir isi gorub bir cavab qaytaran metodlar returnu olan
        //delegatede bele 2-ci metodlara bir cavab qaytaran return - u olan Metodlara Function-lar deyilir.
        //Parametr olaraq Action-lar 16 - a  parametr qebul etmaek iqtidarindadir.
        //Function ise 17 parametr qebul ede bilir. Eslinde o da 16 - qeder parametr qebul ede bilir 17 -ci ise qaytaracagi deyer olur.
        #endregion
        #region Delegate Giris
        public static void Test(string str, DelegateTest Test1)
        {
            Console.WriteLine(str);
            Test1(str);
        }

        public static void Test1(string str1)
        {
            Console.WriteLine(str1);
        }

        public static void Test2(string str2)
        {
            Console.WriteLine(str2);
        }
        public static void Test3(string str3)
        {
            Console.WriteLine(str3);
        }

        public static void Test4(string str4)
        {
            Console.WriteLine(str4);
        }
        #endregion
        #region LambaExpression 2 parametrde Yazilisi Lesson2
        public static void ShortInfo1(string name, int age)
        {
            Console.WriteLine("Person name is:{0} and age is{1}",name, age);
          
        }
        public static void ShortInfo2(string name, int age)
        {
            Console.WriteLine("Person name is:{0} and age is{1}", name, age);

        }
        public static void ShortInfo3(string name, int age)
        {
            Console.WriteLine("Person name is:{0} and age is{1}", name, age);

        }
        #endregion
        #region Action(Delegate)
        public static void ShortInfo4(string name, int age)
        {
            Console.WriteLine("Person name is:{0} and age is{1}", name, age);
        }
        public static void ShortInfo5(string name, int age)
        {
            Console.WriteLine("Person name is:{0} and age is{1}", name, age);
        }
        #endregion
        #region Func(Delegate)
        public static string ShortInfo6(string name, int age)
        {
            string str = $"Person name is: {name} and age is {age} 1";
            return str;
        }
        public static string ShortInfo7(string name, int age)
        {
            string str = $"Person name is: {name} and age is {age} 2";
            return str;
        }
        #endregion
    }
}



