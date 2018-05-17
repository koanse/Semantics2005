using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Semantics
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            /*OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=\"C:\\Documents and Settings\\COMP\\Мои документы\\Работа бакалавра\\db.mdb\"");
            conn.Open();
            DataAdapter da = new DataAdapter(conn);
            Форма[] arrФорма = da.НайтиФормы("стол");
            conn.Close();*/

            /*DataAdapter da = new DataAdapter(conn);
            da.СоздатьОкончание(1, "dd", "gg", "jh");
            da.СоздатьОснову(ЧастьРечи.Глаг, 4, "ff", "gg", "hh", 1);
            da.СоздатьФорму(0, 1);*/
        }
    }

    public enum ЧастьРечи : byte
    {
        Неопр, Сущ, Прил, Числ, Глаг, Нар, Мест,
        Предл, Союз, Част, Межд
    }
    public enum Род
    {
        Неопр, Муж, Жен, Сред
    }
    public enum Число
    {
        Неопр, Ед, Мн
    }
    public enum Падеж
    {
        Неопр, Им, Род, Дат, Вин, Тв, Пр
    }
    public enum Одушевленность
    {
        Неопр, Одуш, Неодуш
    }
    public enum РазрядПрил
    {
        Неопр, Кач, Отн, Прит
    }
    public enum Краткость
    {
        Неопр, Кратк, Полн
    }
    public enum СтепеньСр
    {
        Неопр, Нет, Сравн, Прев
    }
    public enum СоставСтСр
    {
        Неопр, Прост, Сост
    }
    public enum Лицо
    {
        Неопр, Перв, Втор, Тр
    }
    public enum ЗначениеМест
    {
        Неопр, Личн, Возвр, Притяж, Указат, Опред, Вопр, Относит, Отриц
    }
    public enum ФормаГлаг
    {
        Неопр, Инф, Личн, Безл, Прич, Деепр
    }
    public enum ВидГлаг
    {
        Неопр, Сов, Несов
    }
    public enum Переходность
    {
        Неопр, Перех, Неперех
    }
    public enum Возвратность
    {
        Неопр, Возвр, Невозвр
    }
    public enum Залог
    {
        Неопр, Действ, Страдат
    }
    public enum Наклонение
    {
        Неопр, Изъяв, Повел, Усл
    }
    public enum Время
    {
        Неопр, Прош, Наст, Буд
    }
    public enum ЗначениеНар
    {
        Неопр, Опр, Обст
    }
    public enum ЗначОпрНар
    {
        Неопр, Кач, Колич
    }
    public enum ЗначОбстНар
    {
        Неопр, Места, Времени, Причины, Цели
    }
    public enum КатегорияСост
    {
        Неопр, КатСост, НеКатСост
    }
    public enum ТипЧисл
    {
        Неопр, Колич, Поряд
    }
    public enum ТипКолЧисл
    {
        Неопр, Цел, Дробн, Собират
    }
    public enum СоставЧисл
    {
        Неопр, Прост, Сост
    }
    public enum ЗначениеПредл
    {
        Неопр, Объектн, Пространст, Врем, Причин,
        Целев, Сравнит, ОбразаДейств, Определит
    }
    public enum СоставПредл
    {
        Неопр, Прост, Сложн
    }
    public enum СоставСоюз
    {
        Неопр, Прост, Сост
    }
    public enum ТипСоюз
    {
        Неопр, Соч, Подч
    }
    public enum ТипСочСоюз
    {
        Неопр, Соед, Раздел, Противит, Градацион, Поясн, Присоед
    }
    public enum ТипПодчСоюз
    {
        Неопр, Врем, Прич, Усл, Целев, Уступит, Следств, Сравн, Изъяв, Составн
    }
    public enum РазрядЧаст
    {
        Неопр, Смысл, Формообр
    }
    public enum ТипСмыслЧаст
    {
        Неопр, Отриц, Вопр, Указат, Уточн,
        ОграничВыделит, Восклиц, Усил, Сомнен
    }
    public enum ЗначениеМежд
    {
        Неопр, Эмоц, Императ, Этик
    }

    public interface IПостПризнак
    {
        void Initialize(int index);
        int GetIndex();
        string ToString();
        int[] GetLegalValues();
    }
    public interface IИзмПризнак
    {
        void Initialize(int index);
        int GetIndex();
        string ToString();
        int[] GetLegalValues(int кодПостПризн);
    }
    public class ПостПризнСущ : IПостПризнак
    {
        public Род род = Род.Неопр;
        public Одушевленность одушевленность = Одушевленность.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(Род))).Length,
            ((int[])Enum.GetValues(typeof(Одушевленность))).Length
        });
        public ПостПризнСущ() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            род = (Род)indexes[0];
            одушевленность = (Одушевленность)indexes[1];
        }
        public int GetIndex()
        {
            int[] indexes = new int[2];
            indexes[0] = (int)род;
            indexes[1] = (int)одушевленность;
            return (byte)lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return одушевленность.ToString() + ", " + род.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            Род[] arrРод = new Род[] { Род.Муж, Род.Жен, Род.Сред, Род.Неопр };
            Одушевленность[] arrОдуш = new Одушевленность[] { Одушевленность.Одуш,
                Одушевленность.Неодуш };
            ПостПризнСущ attr = new ПостПризнСущ();
            foreach (Одушевленность о in arrОдуш)
                foreach (Род р in arrРод)
                {                    
                    attr.род = р;
                    attr.одушевленность = о;
                    res.Add(attr.GetIndex());
                }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ИзмПризнСущ : IИзмПризнак
    {
        public Число число = Число.Неопр;
        public Падеж падеж = Падеж.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(Число))).Length,
            ((int[])Enum.GetValues(typeof(Падеж))).Length
        });
        public ИзмПризнСущ() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            число = (Число)indexes[0];
            падеж = (Падеж)indexes[1];
        }
        public int GetIndex()
        {
            int[] indexes = new int[2];
            indexes[0] = (int)число;
            indexes[1] = (int)падеж;
            return (int)lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return число.ToString() + ", " + падеж.ToString();
        }
        public int[] GetLegalValues(int кодПостПризн)
        {
            ПостПризнСущ постПризн = new ПостПризнСущ();
            постПризн.Initialize(кодПостПризн);
            ArrayList res = new ArrayList();
            Число[] arrЧисло;
            Падеж[] arrПадеж = new Падеж[] { Падеж.Им, Падеж.Род,
                    Падеж.Дат, Падеж.Вин, Падеж.Тв, Падеж.Пр };
            if (постПризн.род != Род.Неопр)
                arrЧисло = new Число[] { Число.Ед, Число.Мн };
            else
                arrЧисло = new Число[] { Число.Мн };
            ИзмПризнСущ attr = new ИзмПризнСущ();
            foreach (Число ч in arrЧисло)
                foreach (Падеж п in arrПадеж)
                {                    
                    attr.число = ч;
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }
            return (int[])res.ToArray(typeof(int));
        }
    }
    // кач.: большой, отн.: деревянный
    public class ПостПризнПрил : IПостПризнак
    {
        public РазрядПрил разряд = РазрядПрил.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(РазрядПрил))).Length,
        });
        public ПостПризнПрил() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            разряд = (РазрядПрил)indexes[0];
        }
        public int GetIndex()
        {
            int[] indexes = new int[1];
            indexes[0] = (int)разряд;
            return (byte)lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return разряд.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            РазрядПрил[] arrРазряд = new РазрядПрил[] { РазрядПрил.Кач,
                РазрядПрил.Отн, РазрядПрил.Прит };
            ПостПризнПрил attr = new ПостПризнПрил();
            foreach (РазрядПрил р in arrРазряд)
            {                
                attr.разряд = р;
                res.Add(attr.GetIndex());
            }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ИзмПризнПрил : IИзмПризнак
    {
        public Род род = Род.Неопр;
        public Число число = Число.Неопр;
        public Падеж падеж = Падеж.Неопр;
        public Краткость краткость = Краткость.Неопр;
        public СтепеньСр степень = СтепеньСр.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(Род))).Length,
            ((int[])Enum.GetValues(typeof(Число))).Length,
            ((int[])Enum.GetValues(typeof(Падеж))).Length,
            ((int[])Enum.GetValues(typeof(Краткость))).Length,
            ((int[])Enum.GetValues(typeof(СтепеньСр))).Length
        });
        public ИзмПризнПрил() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            род = (Род)indexes[0];
            число = (Число)indexes[1];
            падеж = (Падеж)indexes[2];
            краткость = (Краткость)indexes[3];
            степень = (СтепеньСр)indexes[4];
        }
        public int GetIndex()
        {
            int[] indexes = new int[5];
            indexes[0] = (int)род;
            indexes[1] = (int)число;
            indexes[2] = (int)падеж;
            indexes[3] = (int)краткость;
            indexes[4] = (int)степень;
            return (int)lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return род.ToString() + ", " + число.ToString() + ", " +
                падеж.ToString() + ", " + краткость.ToString() + ", " +
                степень.ToString();
        }
        public int[] GetLegalValues(int кодПостПризн)
        {
            ПостПризнПрил постПризн = new ПостПризнПрил();
            постПризн.Initialize(кодПостПризн);
            ArrayList res = new ArrayList();
            Род[] arrРод = new Род[] { Род.Муж, Род.Жен, Род.Сред };
            Число[] arrЧисло = new Число[] { Число.Ед, Число.Мн };
            Падеж[] arrПадеж = new Падеж[] { Падеж.Им, Падеж.Род,
                    Падеж.Дат, Падеж.Вин, Падеж.Тв, Падеж.Пр };
            ИзмПризнПрил attr = new ИзмПризнПрил();
            if (постПризн.разряд == РазрядПрил.Кач)
            {
                СтепеньСр[] arrСтепень = new СтепеньСр[] { СтепеньСр.Нет,
                    СтепеньСр.Прев };
                foreach (СтепеньСр с in arrСтепень)
                {
                    attr.число = Число.Ед;
                    attr.краткость = Краткость.Полн;
                    foreach (Род р in arrРод)
                        foreach (Падеж п in arrПадеж)
                        {
                            attr.род = р;                            
                            attr.падеж = п;                            
                            attr.степень = с;
                            res.Add(attr.GetIndex());
                        }
                    attr.род = Род.Неопр;
                    attr.число = Число.Мн;
                    foreach (Падеж п in arrПадеж)
                    {                        
                        
                        attr.падеж = п;
                        attr.степень = с;
                        res.Add(attr.GetIndex());
                    }
                }

                attr = new ИзмПризнПрил();
                attr.краткость = Краткость.Кратк;
                foreach (Род р in arrРод)
                {                    
                    attr.род = р;                    
                    res.Add(attr.GetIndex());
                }
                attr.род = Род.Неопр;
                attr.число = Число.Мн;
                res.Add(attr.GetIndex());

                attr = new ИзмПризнПрил();
                attr.степень = СтепеньСр.Сравн;
                res.Add(attr.GetIndex());
            }
            else
            {
                attr.число = Число.Ед;
                foreach (Род р in arrРод)
                    foreach (Падеж п in arrПадеж)
                    {
                        attr.род = р;                        
                        attr.падеж = п;
                        res.Add(attr.GetIndex());
                    }
                attr.число = Число.Мн;
                foreach (Падеж п in arrПадеж)
                {
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }
            }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнЧисл : IПостПризнак
    {
        public ТипЧисл тип = ТипЧисл.Неопр;
        public ТипКолЧисл типКолЧисл = ТипКолЧисл.Неопр;
        public СоставЧисл состав = СоставЧисл.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(ТипЧисл))).Length,
            ((int[])Enum.GetValues(typeof(ТипКолЧисл))).Length,
            ((int[])Enum.GetValues(typeof(СоставЧисл))).Length,
        });
        public ПостПризнЧисл() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            тип = (ТипЧисл)indexes[0];
            типКолЧисл = (ТипКолЧисл)indexes[1];
            состав = (СоставЧисл)indexes[2];            
        }
        public int GetIndex()
        {
            int[] indexes = new int[3];
            indexes[0] = (int)тип;
            indexes[1] = (int)типКолЧисл;
            indexes[2] = (int)состав;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return тип.ToString() + ", " + типКолЧисл.ToString() + ", " +
                состав.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            ПостПризнЧисл attr = new ПостПризнЧисл();
            attr.тип = ТипЧисл.Колич;
            attr.состав = СоставЧисл.Прост;
            ТипКолЧисл[] arrТипКолЧисл = new ТипКолЧисл[] {
                ТипКолЧисл.Цел, ТипКолЧисл.Собират };
            foreach (ТипКолЧисл т in arrТипКолЧисл)
            {
                attr.типКолЧисл = т;
                res.Add(attr.GetIndex());
            }
            attr.тип = ТипЧисл.Поряд;
            attr.состав = СоставЧисл.Прост;
            attr.типКолЧисл = ТипКолЧисл.Неопр;
            res.Add(attr.GetIndex());
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ИзмПризнЧисл : IИзмПризнак
    {
        public Род род = Род.Неопр;
        public Число число = Число.Неопр;
        public Падеж падеж = Падеж.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(Род))).Length,
            ((int[])Enum.GetValues(typeof(Число))).Length,
            ((int[])Enum.GetValues(typeof(Падеж))).Length,
        });
        public ИзмПризнЧисл() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            род = (Род)indexes[0];
            число = (Число)indexes[1];
            падеж = (Падеж)indexes[2];
        }
        public int GetIndex()
        {
            int[] indexes = new int[3];
            indexes[0] = (int)род;
            indexes[1] = (int)число;
            indexes[2] = (int)падеж;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return род.ToString() + ", " + число.ToString() + ", " +
                падеж.ToString();
        }
        public int[] GetLegalValues(int кодПостПризн)
        {
            ПостПризнЧисл постПризн = new ПостПризнЧисл();
            постПризн.Initialize(кодПостПризн);
            ArrayList res = new ArrayList();
            Род[] arrРод = new Род[] { Род.Муж, Род.Жен, Род.Сред };
            Число[] arrЧисло = new Число[] { Число.Ед, Число.Мн };
            Падеж[] arrПадеж = new Падеж[] { Падеж.Им, Падеж.Род,
                    Падеж.Дат, Падеж.Вин, Падеж.Тв, Падеж.Пр };
            ИзмПризнЧисл attr = new ИзмПризнЧисл();
            attr.число = Число.Ед;
            foreach (Род р in arrРод)
                foreach (Падеж п in arrПадеж)
                {
                    attr.род = р;
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }
            attr.число = Число.Мн;
            attr.род = Род.Неопр;
            foreach (Падеж п in arrПадеж)
            {                
                attr.падеж = п;
                res.Add(attr.GetIndex());
            }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнГлаг : IПостПризнак
    {
        public ВидГлаг вид = ВидГлаг.Неопр;
        public Переходность переходность = Переходность.Неопр;
        public Возвратность возвратность = Возвратность.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(ВидГлаг))).Length,
            ((int[])Enum.GetValues(typeof(Переходность))).Length,
            ((int[])Enum.GetValues(typeof(Возвратность))).Length,
        });
        public ПостПризнГлаг() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            вид = (ВидГлаг)indexes[0];
            переходность = (Переходность)indexes[1];
            возвратность = (Возвратность)indexes[2];
        }
        public int GetIndex()
        {
            int[] indexes = new int[3];
            indexes[0] = (int)вид;
            indexes[1] = (int)переходность;
            indexes[2] = (int)возвратность;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return вид.ToString() + ", " + переходность.ToString() + ", " +
                возвратность.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            ПостПризнГлаг attr = new ПостПризнГлаг();
            ВидГлаг[] arrВидГлаг = new ВидГлаг[] { ВидГлаг.Сов, ВидГлаг.Несов };
            Переходность[] arrПереходность = new Переходность[] {
                Переходность.Перех, Переходность.Неперех };
            Возвратность[] arrВозвратность = new Возвратность[] {
                Возвратность.Возвр, Возвратность.Невозвр };            
            foreach (ВидГлаг в in arrВидГлаг)
                foreach (Переходность п in arrПереходность)
                    foreach (Возвратность вз in arrВозвратность)
                    {
                        attr.вид = в;
                        attr.переходность = п;
                        attr.возвратность = вз;
                        res.Add(attr.GetIndex());
                    }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ИзмПризнГлаг : IИзмПризнак
    {
        public ФормаГлаг форма = ФормаГлаг.Неопр;
        public Род род = Род.Неопр;
        public Число число = Число.Неопр;
        public Падеж падеж = Падеж.Неопр;
        public Краткость краткость = Краткость.Неопр;
        public Залог залог = Залог.Неопр;
        public Время время = Время.Неопр;
        public Наклонение наклонение = Наклонение.Неопр;
        public Лицо лицо = Лицо.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(ФормаГлаг))).Length,
            ((int[])Enum.GetValues(typeof(Род))).Length,
            ((int[])Enum.GetValues(typeof(Число))).Length,
            ((int[])Enum.GetValues(typeof(Падеж))).Length,
            ((int[])Enum.GetValues(typeof(Краткость))).Length,
            ((int[])Enum.GetValues(typeof(Залог))).Length,
            ((int[])Enum.GetValues(typeof(Время))).Length,
            ((int[])Enum.GetValues(typeof(Наклонение))).Length,
            ((int[])Enum.GetValues(typeof(Лицо))).Length
        });
        public ИзмПризнГлаг() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            форма = (ФормаГлаг)indexes[0];
            род = (Род)indexes[1];
            число = (Число)indexes[2];
            падеж = (Падеж)indexes[3];
            краткость = (Краткость)indexes[4];
            залог = (Залог)indexes[5];
            время = (Время)indexes[6];
            наклонение = (Наклонение)indexes[7];
            лицо = (Лицо)indexes[8];
        }
        public int GetIndex()
        {
            int[] indexes = new int[9];
            indexes[0] = (int)форма;
            indexes[1] = (int)род;
            indexes[2] = (int)число;
            indexes[3] = (int)падеж;
            indexes[4] = (int)краткость;
            indexes[5] = (int)залог;
            indexes[6] = (int)время;
            indexes[7] = (int)наклонение;
            indexes[8] = (int)лицо;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return форма.ToString() + ", " + род.ToString() + ", " +
                число.ToString() + ", " + падеж.ToString() + ", " +
                краткость.ToString() + ", " + залог.ToString() + ", " +
                время.ToString() + ", " + наклонение.ToString() + ", " +
                лицо.ToString();
        }
        public int[] GetLegalValues(int кодПостПризн)
        {
            ПостПризнГлаг постПризн = new ПостПризнГлаг();
            постПризн.Initialize(кодПостПризн);
            ArrayList res = new ArrayList();

            // инфинитив
            ИзмПризнГлаг attr = new ИзмПризнГлаг();
            attr.форма = ФормаГлаг.Инф;
            res.Add(attr.GetIndex());

            // личн.
            attr.форма = ФормаГлаг.Личн;
            attr.наклонение = Наклонение.Изъяв;
            attr.время = Время.Прош;
            attr.число = Число.Ед;
            Род[] arrРод = new Род[] { Род.Муж, Род.Жен, Род.Сред };
            foreach (Род р in arrРод)
            {
                attr.род = р;
                res.Add(attr.GetIndex());
            }
            attr.род = Род.Неопр;
            attr.число = Число.Мн;
            res.Add(attr.GetIndex());

            Лицо[] arrЛицо = new Лицо[] { Лицо.Перв, Лицо.Втор, Лицо.Тр };
            Число[] arrЧисло = new Число[] { Число.Ед, Число.Мн };
            if (постПризн.вид == ВидГлаг.Несов)
            {
                attr = new ИзмПризнГлаг();
                attr.форма = ФормаГлаг.Личн;
                attr.наклонение = Наклонение.Изъяв;
                attr.время = Время.Наст;                
                foreach (Лицо л in arrЛицо)
                    foreach (Число ч in arrЧисло)
                    {
                        attr.лицо = л;
                        attr.число = ч;
                        res.Add(attr.GetIndex());
                    }
            }

            if (постПризн.вид == ВидГлаг.Сов)
            {
                attr = new ИзмПризнГлаг();
                attr.форма = ФормаГлаг.Личн;
                attr.наклонение = Наклонение.Изъяв;
                attr.время = Время.Буд;
                foreach (Лицо л in arrЛицо)
                    foreach (Число ч in arrЧисло)
                    {
                        attr.лицо = л;
                        attr.число = ч;
                        res.Add(attr.GetIndex());
                    }
            }

            attr = new ИзмПризнГлаг();
            attr.форма = ФормаГлаг.Личн;
            attr.наклонение = Наклонение.Повел;
            res.Add(attr.GetIndex());

            // причастия
            attr = new ИзмПризнГлаг();
            Падеж[] arrПадеж = new Падеж[] { Падеж.Им, Падеж.Род,
                Падеж.Дат, Падеж.Вин, Падеж.Тв, Падеж.Пр };
            
            // действит. прош.
            attr.форма = ФормаГлаг.Прич;
            attr.время = Время.Прош;
            attr.залог = Залог.Действ;
            attr.число = Число.Ед;
            foreach (Род р in arrРод)
                foreach (Падеж п in arrПадеж)
                {
                    attr.род = р;
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }
            attr.число = Число.Мн;
            attr.род = Род.Неопр;
            foreach (Падеж п in arrПадеж)
            {
                attr.падеж = п;
                res.Add(attr.GetIndex());
            }
             
            // действит. наст.
            if (постПризн.вид == ВидГлаг.Несов)
            {
                attr = new ИзмПризнГлаг();
                attr.форма = ФормаГлаг.Прич;
                attr.время = Время.Наст;
                attr.залог = Залог.Действ;
                attr.число = Число.Ед;
                foreach (Род р in arrРод)
                    foreach (Падеж п in arrПадеж)
                    {
                        attr.род = р;
                        attr.падеж = п;
                        res.Add(attr.GetIndex());
                    }
                attr.число = Число.Мн;
                attr.род = Род.Неопр;
                foreach (Падеж п in arrПадеж)
                {
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }
            }

            // страд. прош.
            if (постПризн.вид == ВидГлаг.Несов &&
                постПризн.переходность == Переходность.Перех ||
                постПризн.вид == ВидГлаг.Сов &&
                постПризн.переходность == Переходность.Перех)
            {
                attr = new ИзмПризнГлаг();
                attr.форма = ФормаГлаг.Прич;
                attr.время = Время.Прош;
                attr.залог = Залог.Страдат;
                attr.краткость = Краткость.Полн;
                attr.число = Число.Ед;
                foreach (Род р in arrРод)
                    foreach (Падеж п in arrПадеж)
                    {
                        attr.род = р;
                        attr.падеж = п;
                        res.Add(attr.GetIndex());
                    }
                attr.число = Число.Мн;
                attr.род = Род.Неопр;
                foreach (Падеж п in arrПадеж)
                {
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }

                attr = new ИзмПризнГлаг();
                attr.форма = ФормаГлаг.Прич;
                attr.время = Время.Прош;
                attr.залог = Залог.Страдат;
                attr.краткость = Краткость.Кратк;
                attr.число = Число.Ед;
                foreach (Род р in arrРод)
                {
                    attr.род = р;
                    res.Add(attr.GetIndex());
                }
                attr.число = Число.Мн;
                attr.род = Род.Неопр;
                res.Add(attr.GetIndex());
            }

            // страд. наст.
            if (постПризн.вид == ВидГлаг.Несов &&
                постПризн.переходность == Переходность.Перех)
            {
                attr = new ИзмПризнГлаг();
                attr.форма = ФормаГлаг.Прич;
                attr.время = Время.Наст;
                attr.залог = Залог.Страдат;
                attr.краткость = Краткость.Полн;
                attr.число = Число.Ед;
                foreach (Род р in arrРод)
                    foreach (Падеж п in arrПадеж)
                    {
                        attr.род = р;
                        attr.падеж = п;
                        res.Add(attr.GetIndex());
                    }
                attr.род = Род.Неопр;
                attr.число = Число.Мн;
                foreach (Падеж п in arrПадеж)
                {
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }

                attr = new ИзмПризнГлаг();
                attr.форма = ФормаГлаг.Прич;
                attr.время = Время.Наст;
                attr.залог = Залог.Страдат;
                attr.краткость = Краткость.Кратк;
                attr.число = Число.Ед;
                foreach (Род р in arrРод)
                {
                    attr.род = р;
                    res.Add(attr.GetIndex());
                }
                attr.число = Число.Мн;
                attr.род = Род.Неопр;
                res.Add(attr.GetIndex());
            }
            // дееприч.
            attr = new ИзмПризнГлаг();
            attr.форма = ФормаГлаг.Деепр;
            res.Add(attr.GetIndex());
            
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнНар : IПостПризнак
    {
        public ЗначениеНар значение = ЗначениеНар.Неопр;
        public ЗначОпрНар значОпрНар = ЗначОпрНар.Неопр;
        public ЗначОбстНар значОбстНар = ЗначОбстНар.Неопр;
        public КатегорияСост катСост = КатегорияСост.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(ЗначениеНар))).Length,
            ((int[])Enum.GetValues(typeof(ЗначОпрНар))).Length,
            ((int[])Enum.GetValues(typeof(ЗначОбстНар))).Length,
            ((int[])Enum.GetValues(typeof(КатегорияСост))).Length
        });
        public ПостПризнНар() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            значение = (ЗначениеНар)indexes[0];
            значОпрНар = (ЗначОпрНар)indexes[1];
            значОбстНар = (ЗначОбстНар)indexes[2];
            катСост = (КатегорияСост)indexes[3];
        }
        public int GetIndex()
        {
            int[] indexes = new int[4];
            indexes[0] = (int)значение;
            indexes[1] = (int)значОпрНар;
            indexes[2] = (int)значОбстНар;
            indexes[3] = (int)катСост;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return значение.ToString() + ", " + значОпрНар.ToString() + ", " +
                значОбстНар.ToString() + ", " + катСост.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            ПостПризнНар attr = new ПостПризнНар();
            ЗначОпрНар[] arrЗначОпрНар = new ЗначОпрНар[] { ЗначОпрНар.Кач,
                ЗначОпрНар.Колич };
            КатегорияСост[] arrКатегорияСост = new КатегорияСост[] {
                КатегорияСост.КатСост, КатегорияСост.НеКатСост };
            attr.значение = ЗначениеНар.Опр;
            foreach (ЗначОпрНар з in arrЗначОпрНар)
                foreach (КатегорияСост к in arrКатегорияСост)
                {
                    attr.значОпрНар = з;
                    attr.катСост = к;
                    res.Add(attr.GetIndex());
                }

            ЗначОбстНар[] arrЗначОбстНар = new ЗначОбстНар[] { ЗначОбстНар.Места,
                ЗначОбстНар.Времени, ЗначОбстНар.Причины, ЗначОбстНар.Цели };
            attr.значение = ЗначениеНар.Обст;
            foreach (ЗначОбстНар з in arrЗначОбстНар)
            {
                attr.значОбстНар = з;
                res.Add(attr.GetIndex());
            }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ИзмПризнНар : IИзмПризнак
    {
        public СтепеньСр степень = СтепеньСр.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(СтепеньСр))).Length
        });
        public ИзмПризнНар() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            степень = (СтепеньСр)indexes[0];
        }
        public int GetIndex()
        {
            int[] indexes = new int[1];
            indexes[0] = (int)степень;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return степень.ToString();
        }
        public int[] GetLegalValues(int кодПостПризн)
        {
            ПостПризнНар постПризн = new ПостПризнНар();
            постПризн.Initialize(кодПостПризн);
            ArrayList res = new ArrayList();
            ИзмПризнНар attr = new ИзмПризнНар();
            if (постПризн.значение == ЗначениеНар.Опр &&
                постПризн.значОпрНар == ЗначОпрНар.Кач)
            {
                СтепеньСр[] arrСтепеньСр = new СтепеньСр[] { СтепеньСр.Нет,
                    СтепеньСр.Сравн };
                foreach (СтепеньСр с in arrСтепеньСр)
                {
                    attr.степень = с;
                    res.Add(attr.GetIndex());
                }
            }
            else
                res.Add(attr.GetIndex());
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнМест : IПостПризнак
    {
        public ЗначениеМест значениеМест = ЗначениеМест.Неопр;
        public Лицо лицо = Лицо.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(ЗначениеМест))).Length,
            ((int[])Enum.GetValues(typeof(Лицо))).Length,
        });
        public ПостПризнМест() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            значениеМест = (ЗначениеМест)indexes[0];
            лицо = (Лицо)indexes[1];
        }
        public int GetIndex()
        {
            int[] indexes = new int[2];
            indexes[0] = (int)значениеМест;
            indexes[1] = (int)лицо;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return значениеМест.ToString() + ", " + лицо.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            ПостПризнМест attr = new ПостПризнМест();
            attr.значениеМест = ЗначениеМест.Личн;
            Лицо[] arrЛицо = new Лицо[] { Лицо.Перв, Лицо.Втор, Лицо.Тр };
            foreach (Лицо л in arrЛицо)
            {
                attr.лицо = л;
                res.Add(attr.GetIndex());
            }

            ЗначениеМест[] arrЗначениеМест = new ЗначениеМест[] { ЗначениеМест.Возвр,
                ЗначениеМест.Вопр, ЗначениеМест.Опред, ЗначениеМест.Относит,
                ЗначениеМест.Отриц, ЗначениеМест.Притяж, ЗначениеМест.Указат };

            attr.лицо = Лицо.Неопр;
            foreach (ЗначениеМест з in arrЗначениеМест)
            {
                attr.значениеМест = з;
                res.Add(attr.GetIndex());
            }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ИзмПризнМест : IИзмПризнак
    {
        public Род род = Род.Неопр;
        public Число число = Число.Неопр;
        public Падеж падеж = Падеж.Неопр;
        public Краткость краткость = Краткость.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(Род))).Length,
            ((int[])Enum.GetValues(typeof(Число))).Length,
            ((int[])Enum.GetValues(typeof(Падеж))).Length,
            ((int[])Enum.GetValues(typeof(Краткость))).Length,
        });
        public ИзмПризнМест() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            род = (Род)indexes[0];
            число = (Число)indexes[1];
            падеж = (Падеж)indexes[2];
            краткость = (Краткость)indexes[3];
        }
        public int GetIndex()
        {
            int[] indexes = new int[4];
            indexes[0] = (int)род;
            indexes[1] = (int)число;
            indexes[2] = (int)падеж;
            indexes[3] = (int)краткость;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return род.ToString() + ", " + число.ToString() + ", " +
                падеж.ToString() + ", " + краткость.ToString();
        }
        public int[] GetLegalValues(int кодПостПризн)
        {
            ПостПризнМест постПризн = new ПостПризнМест();
            постПризн.Initialize(кодПостПризн);
            ArrayList res = new ArrayList();
            ИзмПризнМест attr = new ИзмПризнМест();

            Род[] arrРод = new Род[] { Род.Муж, Род.Жен, Род.Сред };
            Число[] arrЧисло = new Число[] { Число.Ед, Число.Мн };
            Падеж[] arrПадеж = new Падеж[] { Падеж.Им, Падеж.Род,
                    Падеж.Дат, Падеж.Вин, Падеж.Тв, Падеж.Пр };

            attr.число = Число.Ед;
            foreach (Род р in arrРод)
                foreach (Падеж п in arrПадеж)
                {
                    attr.род = р;
                    attr.падеж = п;
                    res.Add(attr.GetIndex());
                }
            attr.число = Число.Мн;
            attr.род = Род.Неопр;
            foreach (Падеж п in arrПадеж)
            {
                attr.падеж = п;
                res.Add(attr.GetIndex());
            }

            attr = new ИзмПризнМест();
            attr.число = Число.Ед;
            attr.краткость = Краткость.Кратк;
            foreach (Род р in arrРод)
            {
                attr.род = р;
                res.Add(attr.GetIndex());
            }

            attr.число = Число.Мн;
            attr.род = Род.Неопр;
            res.Add(attr.GetIndex());
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнПредл : IПостПризнак
    {
        public ЧастьРечи произвОт = ЧастьРечи.Неопр;
        public СоставПредл состав = СоставПредл.Неопр;
        public ЗначениеПредл значение = ЗначениеПредл.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((byte[])Enum.GetValues(typeof(ЧастьРечи))).Length,
            ((int[])Enum.GetValues(typeof(СоставПредл))).Length,
            ((int[])Enum.GetValues(typeof(ЗначениеПредл))).Length
        });
        public ПостПризнПредл() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            произвОт = (ЧастьРечи)(byte)(indexes[0]);
            состав = (СоставПредл)indexes[1];
            значение = (ЗначениеПредл)indexes[2];
        }
        public int GetIndex()
        {
            int[] indexes = new int[3];
            indexes[0] = (byte)произвОт;
            indexes[1] = (int)состав;
            indexes[2] = (int)значение;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return произвОт.ToString() + ", " + состав.ToString() +
                ", " + значение.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            ПостПризнПредл attr = new ПостПризнПредл();
            ЧастьРечи[] arrПроизОт = new ЧастьРечи[] { ЧастьРечи.Сущ,
                ЧастьРечи.Прил, ЧастьРечи.Глаг, ЧастьРечи.Нар,
                ЧастьРечи.Неопр };
            СоставПредл[] arrСоставПредл = new СоставПредл[] {
                СоставПредл.Прост, СоставПредл.Сложн };
            ЗначениеПредл[] arrЗначение = new ЗначениеПредл[] { ЗначениеПредл.Врем,
                ЗначениеПредл.ОбразаДейств, ЗначениеПредл.Объектн, ЗначениеПредл.Определит,
                ЗначениеПредл.Причин, ЗначениеПредл.Пространст, ЗначениеПредл.Сравнит,
                ЗначениеПредл.Целев };
            foreach (ЧастьРечи ч in arrПроизОт)
                foreach (СоставПредл с in arrСоставПредл)
                    foreach (ЗначениеПредл з in arrЗначение)
                    {
                        attr.произвОт = ч;
                        attr.состав = с;
                        attr.значение = з;
                        res.Add(attr.GetIndex());
                    }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнСоюз : IПостПризнак
    {
        public СоставСоюз состав = СоставСоюз.Неопр;
        public ТипСоюз тип = ТипСоюз.Неопр;
        public ТипСочСоюз типСочСоюз = ТипСочСоюз.Неопр;
        public ТипПодчСоюз типПодчСоюз = ТипПодчСоюз.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(СоставСоюз))).Length,
            ((int[])Enum.GetValues(typeof(ТипСоюз))).Length,
            ((int[])Enum.GetValues(typeof(ТипСочСоюз))).Length,
            ((int[])Enum.GetValues(typeof(ТипПодчСоюз))).Length
        });
        public ПостПризнСоюз() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            состав = (СоставСоюз)indexes[0];
            тип = (ТипСоюз)indexes[1];
            типСочСоюз = (ТипСочСоюз)indexes[2];
            типПодчСоюз = (ТипПодчСоюз)indexes[3];
        }
        public int GetIndex()
        {
            int[] indexes = new int[4];
            indexes[0] = (int)состав;
            indexes[1] = (int)тип;
            indexes[2] = (int)типСочСоюз;
            indexes[3] = (int)типПодчСоюз;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return состав.ToString() + ", "  + тип.ToString() +
                ", " + типСочСоюз.ToString() + ", " + типПодчСоюз.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            СоставСоюз[] arrСостав = new СоставСоюз[] {
                СоставСоюз.Прост, СоставСоюз.Сост };
            ТипСочСоюз[] arrТипСочСоюз = new ТипСочСоюз[] { ТипСочСоюз.Градацион,
                ТипСочСоюз.Поясн, ТипСочСоюз.Присоед, ТипСочСоюз.Противит,
                ТипСочСоюз.Раздел, ТипСочСоюз.Соед };
            ТипПодчСоюз[] arrТипПодчСоюз = new ТипПодчСоюз[] { ТипПодчСоюз.Врем,
                ТипПодчСоюз.Изъяв, ТипПодчСоюз.Прич, ТипПодчСоюз.Следств,
                ТипПодчСоюз.Составн, ТипПодчСоюз.Сравн, ТипПодчСоюз.Усл,
                ТипПодчСоюз.Уступит, ТипПодчСоюз.Целев };
            
            ПостПризнСоюз attr = new ПостПризнСоюз();
            attr.тип = ТипСоюз.Соч;
            foreach (СоставСоюз с in arrСостав)
                foreach (ТипСочСоюз т in arrТипСочСоюз)
                {
                    attr.типСочСоюз = т;
                    attr.состав = с;
                    res.Add(attr.GetIndex());
                }

            attr = new ПостПризнСоюз();
            attr.тип = ТипСоюз.Подч;
            foreach (СоставСоюз с in arrСостав)
                foreach (ТипПодчСоюз т in arrТипПодчСоюз)
                {
                    attr.типПодчСоюз = т;
                    attr.состав = с;
                    res.Add(attr.GetIndex());
                }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнЧаст : IПостПризнак
    {
        public РазрядЧаст разряд = РазрядЧаст.Неопр;
        public ТипСмыслЧаст типСмыслЧаст = ТипСмыслЧаст.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(РазрядЧаст))).Length,
            ((int[])Enum.GetValues(typeof(ТипСмыслЧаст))).Length,
        });
        public ПостПризнЧаст() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            разряд = (РазрядЧаст)indexes[0];
            типСмыслЧаст = (ТипСмыслЧаст)indexes[1];
        }
        public int GetIndex()
        {
            int[] indexes = new int[2];
            indexes[0] = (int)разряд;
            indexes[1] = (int)типСмыслЧаст;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return разряд.ToString() + ", " + типСмыслЧаст.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            ПостПризнЧаст attr = new ПостПризнЧаст();
            ТипСмыслЧаст[] arrТипСмыслЧаст = new ТипСмыслЧаст[] { ТипСмыслЧаст.Вопр,
                ТипСмыслЧаст.Восклиц, ТипСмыслЧаст.ОграничВыделит,
                ТипСмыслЧаст.Отриц, ТипСмыслЧаст.Сомнен, ТипСмыслЧаст.Указат,
                ТипСмыслЧаст.Усил, ТипСмыслЧаст.Уточн, ТипСмыслЧаст.Неопр };

            attr.разряд = РазрядЧаст.Формообр;
            res.Add(attr.GetIndex());

            attr.разряд = РазрядЧаст.Смысл;
            foreach (ТипСмыслЧаст т in arrТипСмыслЧаст)
            {
                attr.типСмыслЧаст = т;
                res.Add(attr.GetIndex());
            }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПостПризнМежд : IПостПризнак
    {
        public ЗначениеМежд значение = ЗначениеМежд.Неопр;
        static Linearizer lin = new Linearizer(new int[] {
            ((int[])Enum.GetValues(typeof(ЗначениеМежд))).Length,
        });
        public ПостПризнМежд() { }
        public void Initialize(int index)
        {
            int[] indexes = lin.GetIndexes(index);
            значение = (ЗначениеМежд)indexes[0];
        }
        public int GetIndex()
        {
            int[] indexes = new int[1];
            indexes[0] = (int)значение;
            return lin.GetIndex(indexes);
        }
        public override string ToString()
        {
            return значение.ToString();
        }
        public int[] GetLegalValues()
        {
            ArrayList res = new ArrayList();
            ПостПризнМежд attr = new ПостПризнМежд();
            ЗначениеМежд[] arrЗначение = new ЗначениеМежд[] {
                ЗначениеМежд.Императ, ЗначениеМежд.Эмоц, ЗначениеМежд.Этик,
                ЗначениеМежд.Неопр };
            foreach (ЗначениеМежд з in arrЗначение)
            {
                attr.значение = з;
                res.Add(attr.GetIndex());
            }
            return (int[])res.ToArray(typeof(int));
        }
    }
    public class ПустойПостПризнак : IПостПризнак
    {
        public ПустойПостПризнак() { }
        public void Initialize(int index) { }
        public int GetIndex()
        {
            return 0;
        }
        public override string ToString()
        {
            return "Пустой пост. признак";
        }
        public int[] GetLegalValues()
        {
            return new int[] { 0 };
        }
    }
    public class ПустойИзмПризнак : IИзмПризнак
    {
        public ПустойИзмПризнак() { }
        public void Initialize(int index) { }
        public int GetIndex()
        {
            return 0;
        }
        public override string ToString()
        {
            return "Пустой изм. признак";
        }
        public int[] GetLegalValues(int кодПостПризн)
        {
            return new int[] { 0 };
        }
    }
    public class Linearizer
    {
        int[] dims;
        int maxIndex;
        public Linearizer(int[] dims)
        {
            this.dims = dims;
            maxIndex = 1;
            for (int i = 0; i < dims.Length; i++)
                maxIndex *= (int)dims[i];
        }
        public int GetIndex(int[] indexes)
        {
            if (indexes.Length != dims.Length)
                throw new Exception();
            int index = 0, dim = 1;
            for (int i = 0; i < dims.Length; i++)
            {
                if (indexes[i] >= dims[i])
                    throw new Exception();
                index += indexes[i] * dim;
                dim *= dims[i];
            }
            return (int)index;
        }
        public int[] GetIndexes(int index)
        {
            int[] indexes = new int[dims.Length];
            int dim = maxIndex;
            for (int i = dims.Length - 1; i >= 0; i--)
            {
                dim /= (int)dims[i];
                int j = (int)(index / dim);
                if (j >= dims[i])
                    throw new Exception();
                indexes[i] = j;
                index -= (int)(j * dim);
            }
            return indexes;
        }
    }
    public class ПризнакFactory
    {
        public static IПостПризнак ПостПризнак(ЧастьРечи чр)
        {
            switch (чр)
            {
                case ЧастьРечи.Сущ:
                    return new ПостПризнСущ();
                case ЧастьРечи.Прил:
                    return new ПостПризнПрил();
                case ЧастьРечи.Числ:
                    return new ПостПризнЧисл();
                case ЧастьРечи.Глаг:
                    return new ПостПризнГлаг();
                case ЧастьРечи.Нар:
                    return new ПостПризнНар();
                case ЧастьРечи.Предл:
                    return new ПостПризнПредл();
                case ЧастьРечи.Союз:
                    return new ПостПризнСоюз();
                case ЧастьРечи.Част:
                    return new ПостПризнЧаст();
                case ЧастьРечи.Мест:
                    return new ПостПризнМест();
                case ЧастьРечи.Межд:
                    return new ПостПризнМежд();
                default:
                    return new ПустойПостПризнак();
            }
        }
        public static IИзмПризнак ИзмПризнак(ЧастьРечи чр)
        {
            switch (чр)
            {
                case ЧастьРечи.Сущ:
                    return new ИзмПризнСущ();
                case ЧастьРечи.Прил:
                    return new ИзмПризнПрил();
                case ЧастьРечи.Числ:
                    return new ИзмПризнЧисл();
                case ЧастьРечи.Глаг:
                    return new ИзмПризнГлаг();
                case ЧастьРечи.Нар:
                    return new ИзмПризнНар();
                case ЧастьРечи.Предл:
                    return new ПустойИзмПризнак();
                case ЧастьРечи.Союз:
                    return new ПустойИзмПризнак();
                case ЧастьРечи.Част:
                    return new ПустойИзмПризнак();
                case ЧастьРечи.Мест:
                    return new ИзмПризнМест();
                case ЧастьРечи.Межд:
                    return new ПустойИзмПризнак();
                default:
                    return new ПустойИзмПризнак();
            }
        }
    }

    public class Форма
    {
        public string форма;
        public string начФорма;
        public string осн1, осн2, осн3, оконч1, оконч2, оконч3;
        public ЧастьРечи частьРечи;
        public IПостПризнак постПризн;
        public IИзмПризнак измПризн;
        public bool isНачФорма;

        public Форма() { }
        public Форма(string форма, string начФорма, ЧастьРечи частьРечи,
            int кодПостПризн, int кодИзмПризн,
            string осн1, string осн2, string осн3,
            string оконч1, string оконч2, string оконч3, bool isНачФорма)
        {
            this.форма = осн1 + оконч1 + осн2 + оконч2 + осн3 + оконч3;
            this.начФорма = начФорма;
            this.частьРечи = частьРечи;
            постПризн = ПризнакFactory.ПостПризнак(частьРечи);
            измПризн = ПризнакFactory.ИзмПризнак(частьРечи);            
            постПризн.Initialize(кодПостПризн);
            измПризн.Initialize(кодИзмПризн);
            this.осн1 = осн1;
            this.осн2 = осн2;
            this.осн3 = осн3;
            this.оконч1 = оконч1;
            this.оконч2 = оконч2;
            this.оконч3 = оконч3;
            this.isНачФорма = isНачФорма;
        }
    }
    public class ФормОконч
    {
        string оконч1, оконч2, оконч3, форма;
        int кодОконч;
        public string Форма
        {
            get { return форма; }
            set { форма = value; }
        }
        public int КодОконч
        {
            get { return кодОконч; }
            set { кодОконч = value; }
        }
        public ФормОконч(int кодОконч, string оконч1,
            string оконч2, string оконч3, string форма)
        {
            this.кодОконч = кодОконч;
            this.оконч1 = оконч1;
            this.оконч2 = оконч2;
            this.оконч3 = оконч3;
            this.форма = форма;
        }
        public override string ToString()
        {
            return форма;
        }
    }
    public class DataAdapter
    {
        OleDbCommand cmdNewBasId, cmdNewFormId, cmdNewEndId, cmdNewTemplId;
        OleDbCommand cmdInsBas, cmdInsForm, cmdInsEnd, cmdInsTempl;
        OleDbCommand cmdSelFormByHash, cmdSelFormById;
        OleDbCommand cmdSelEndByAttr, cmdSelEndByEndAttr;
        OleDbCommand cmdUpdBas;
        OleDbCommand cmdGetWordByBasIdEndId, cmdGetWordByFormId;
        static int emptyId = 0;
        public DataAdapter(OleDbConnection conn)
        {
            string str = "SELECT MAX(КодОсновы) + 1 FROM Основы";
            cmdNewBasId = new OleDbCommand(str, conn);

            str = "SELECT MAX(КодФормы) + 1 FROM Формы";
            cmdNewFormId = new OleDbCommand(str, conn);

            str = "SELECT MAX(КодОконч) + 1 FROM Окончания";
            cmdNewEndId = new OleDbCommand(str, conn);

            str = "SELECT MAX(КодОбразца) + 1 FROM Образцы";
            cmdNewTemplId = new OleDbCommand(str, conn);
          
            str = "INSERT INTO Основы(КодОсновы, ЧастьРечи, КодПостПризн, " +
                "Основа1, Основа2, Основа3, КодНачФормы) " +
                "VALUES (@КодОсновы, @ЧастьРечи, @КодПостПризн, " +
                "@Основа1, @Основа2, @Основа3, @КодНачФормы)";
            cmdInsBas = new OleDbCommand(str, conn);
            cmdInsBas.Parameters.Add("@КодОсновы", OleDbType.Integer);
            cmdInsBas.Parameters.Add("@ЧастьРечи", OleDbType.UnsignedTinyInt);
            cmdInsBas.Parameters.Add("@КодПостПризн", OleDbType.Integer);
            cmdInsBas.Parameters.Add("@Основа1", OleDbType.VarWChar, 15);
            cmdInsBas.Parameters.Add("@Основа2", OleDbType.VarWChar, 10);
            cmdInsBas.Parameters.Add("@Основа3", OleDbType.VarWChar, 10);
            cmdInsBas.Parameters.Add("@КодНачФормы", OleDbType.Integer);

            str = "INSERT INTO Окончания(КодОконч, КодИзмПризн, Оконч1, Оконч2, Оконч3) " +
                "VALUES (@КодОконч, @КодИзмПризн, @Оконч1, @Оконч2, @Оконч3)";
            cmdInsEnd = new OleDbCommand(str, conn);
            cmdInsEnd.Parameters.Add("@КодОконч", OleDbType.Integer);
            cmdInsEnd.Parameters.Add("@КодИзмПризн", OleDbType.Integer);
            cmdInsEnd.Parameters.Add("@Оконч1", OleDbType.VarWChar, 10);
            cmdInsEnd.Parameters.Add("@Оконч2", OleDbType.VarWChar, 10);
            cmdInsEnd.Parameters.Add("@Оконч3", OleDbType.VarWChar, 10);

            str = "INSERT INTO Формы(КодФормы, КодОсновы, КодОконч, Хэш) " +
                "VALUES (@КодФормы, @КодОсновы, @КодОконч, @Хэш)";
            cmdInsForm = new OleDbCommand(str, conn);
            cmdInsForm.Parameters.Add("@КодФормы", OleDbType.Integer);
            cmdInsForm.Parameters.Add("@КодОсновы", OleDbType.Integer);
            cmdInsForm.Parameters.Add("@КодОконч", OleDbType.Integer);
            cmdInsForm.Parameters.Add("@Хэш", OleDbType.Integer);

            str = "INSERT INTO Образцы(КодОбразца, КодОсновы, Название, Примечание) " +
                "VALUES (@КодОбразца, @КодОсновы, @Название, @Примечание)";
            cmdInsTempl = new OleDbCommand(str, conn);
            cmdInsTempl.Parameters.Add("@КодОбразца", OleDbType.Integer);
            cmdInsTempl.Parameters.Add("@КодОсновы", OleDbType.Integer);
            cmdInsTempl.Parameters.Add("@Название", OleDbType.VarWChar, 10);
            cmdInsTempl.Parameters.Add("@Примечание", OleDbType.VarWChar, 50);

            str = "UPDATE Основы SET КодНачФормы = @КодНачФормы " +
                "WHERE КодОсновы = @КодОсновы";
            cmdUpdBas = new OleDbCommand(str, conn);
            cmdUpdBas.Parameters.Add("@КодНачФормы", OleDbType.Integer);
            cmdUpdBas.Parameters.Add("@КодОсновы", OleDbType.Integer);

            str = "SELECT Основа1 & Оконч1 & Основа2 & Оконч2 & Основа3 & Оконч3 " +
                "FROM Основы, Окончания " +
                "WHERE КодОсновы = @КодОсновы AND КодОконч = @КодОконч";
            cmdGetWordByBasIdEndId = new OleDbCommand(str, conn);
            cmdGetWordByBasIdEndId.Parameters.Add("@КодОсновы", OleDbType.Integer);
            cmdGetWordByBasIdEndId.Parameters.Add("@КодОконч", OleDbType.Integer);

            str = "SELECT Основа1 & Оконч1 & Основа2 & Оконч2 & Основа3 & Оконч3 " +
                "FROM Основы, Формы, Окончания " +
                "WHERE КодФормы = @КодФормы AND " +
                "Формы.КодОсновы = Основы.КодОсновы AND " +
                "Формы.КодОконч = Окончания.КодОконч";
            cmdGetWordByFormId = new OleDbCommand(str, conn);
            cmdGetWordByFormId.Parameters.Add("@КодФормы", OleDbType.Integer);

            str = "SELECT КодФормы " +
                "FROM Формы " +
                "WHERE Хэш = @Хэш";
            cmdSelFormByHash = new OleDbCommand(str, conn);
            cmdSelFormByHash.Parameters.Add("@Хэш", OleDbType.Integer);

            str = "SELECT КодФормы, КодНачФормы, ЧастьРечи, " +
                "КодПостПризн, КодИзмПризн, Основа1, Основа2, Основа3, " +
                "Оконч1, Оконч2, Оконч3 " +
                "FROM Основы, Формы, Окончания " +
                "WHERE Формы.КодОсновы = Основы.КодОсновы " +
                "AND Формы.КодОконч = Окончания.КодОконч " +
                "AND КодФормы = @КодФормы";
            cmdSelFormById = new OleDbCommand(str, conn);
            cmdSelFormById.Parameters.Add("@КодФормы", OleDbType.Integer);

            str = "SELECT Окончания.КодОконч, Оконч1, Оконч2, Оконч3 " +
                "FROM Основы, Формы, Окончания " +
                "WHERE Основы.КодОсновы = Формы.КодОсновы " +
                "AND Формы.КодОконч = Окончания.КодОконч " +
                "AND ЧастьРечи = @ЧастьРечи " +
                "AND КодПостПризн = @КодПостПризн " +
                "AND КодИзмПризн = @КодИзмПризн";
            cmdSelEndByAttr = new OleDbCommand(str, conn);
            cmdSelEndByAttr.Parameters.Add("@ЧастьРечи",OleDbType.TinyInt);
            cmdSelEndByAttr.Parameters.Add("@КодПостПризн", OleDbType.Integer);
            cmdSelEndByAttr.Parameters.Add("@КодИзмПризн", OleDbType.Integer);

            str = "SELECT КодОконч FROM Окончания " +
                "WHERE КодИзмПризн = @КодИзмПризн " +
                "AND Оконч1 = @Оконч1 " +
                "AND Оконч2 = @Оконч2 " +
                "AND Оконч3 = @Оконч3 ";
            cmdSelEndByEndAttr = new OleDbCommand(str, conn);
            cmdSelEndByEndAttr.Parameters.Add("@КодИзмПризн", OleDbType.Integer);
            cmdSelEndByEndAttr.Parameters.Add("@Оконч1", OleDbType.VarWChar);
            cmdSelEndByEndAttr.Parameters.Add("@Оконч2", OleDbType.VarWChar);
            cmdSelEndByEndAttr.Parameters.Add("@Оконч3", OleDbType.VarWChar);
        }
        public int СоздатьОкончание(int кодИзмПризн,
            string оконч1, string оконч2, string оконч3)
        {
            cmdSelEndByEndAttr.Parameters["@КодИзмПризн"].Value = кодИзмПризн;
            cmdSelEndByEndAttr.Parameters["@Оконч1"].Value = оконч1;
            cmdSelEndByEndAttr.Parameters["@Оконч2"].Value = оконч2;
            cmdSelEndByEndAttr.Parameters["@Оконч3"].Value = оконч3;
            OleDbDataReader reader = cmdSelEndByEndAttr.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int idOld = (int)reader.GetValue(0);
                reader.Close();
                return idOld;
            }
            reader.Close();

            int id = (int)(int)cmdNewEndId.ExecuteScalar();
            cmdInsEnd.Parameters["@КодОконч"].Value = id;
            cmdInsEnd.Parameters["@КодИзмПризн"].Value = кодИзмПризн;
            cmdInsEnd.Parameters["@Оконч1"].Value = оконч1;
            cmdInsEnd.Parameters["@Оконч2"].Value = оконч2;
            cmdInsEnd.Parameters["@Оконч3"].Value = оконч3;
            cmdInsEnd.ExecuteNonQuery();
            return id;
        }
        public int СоздатьОснову(ЧастьРечи частьРечи, int кодПостПризн,
            string основа1, string основа2, string основа3,
            int кодОкончНачФормы)
        {
            int basId = (int)cmdNewBasId.ExecuteScalar();
            cmdInsBas.Parameters["@КодОсновы"].Value = basId;
            cmdInsBas.Parameters["@ЧастьРечи"].Value = (byte)частьРечи;
            cmdInsBas.Parameters["@КодПостПризн"].Value = (byte)кодПостПризн;
            cmdInsBas.Parameters["@Основа1"].Value = основа1;
            cmdInsBas.Parameters["@Основа2"].Value = основа2;
            cmdInsBas.Parameters["@Основа3"].Value = основа3;
            cmdInsBas.Parameters["@КодНачФормы"].Value = emptyId;
            cmdInsBas.ExecuteNonQuery();

            cmdGetWordByBasIdEndId.Parameters["@КодОсновы"].Value = basId;
            cmdGetWordByBasIdEndId.Parameters["@КодОконч"].Value = кодОкончНачФормы;
            string s = (string)cmdGetWordByBasIdEndId.ExecuteScalar();

            int formId = СоздатьФорму(basId, кодОкончНачФормы);
            cmdUpdBas.Parameters["@КодОсновы"].Value = basId;
            cmdUpdBas.Parameters["@КодНачФормы"].Value = formId;
            cmdUpdBas.ExecuteNonQuery();
            return basId;
        }
        public int СоздатьФорму(int кодОсновы, int кодОконч)
        {
            cmdGetWordByBasIdEndId.Parameters["@КодОсновы"].Value = кодОсновы;
            cmdGetWordByBasIdEndId.Parameters["@КодОконч"].Value = кодОконч;
            string s = (string)cmdGetWordByBasIdEndId.ExecuteScalar();

            int id = (int)cmdNewFormId.ExecuteScalar();
            cmdInsForm.Parameters["@КодФормы"].Value = id;
            cmdInsForm.Parameters["@КодОсновы"].Value = кодОсновы;
            cmdInsForm.Parameters["@КодОконч"].Value = кодОконч;
            cmdInsForm.Parameters["@Хэш"].Value = HashFunc(s);
            cmdInsForm.ExecuteNonQuery();
            return id;
        }
        public int СоздатьОбразец(int кодОсновы,
            string название, string примечание)
        {
            int id = (int)cmdNewTemplId.ExecuteScalar();
            cmdInsTempl.Parameters["@КодОбразца"].Value = id;
            cmdInsTempl.Parameters["@КодОсновы"].Value = кодОсновы;
            cmdInsTempl.Parameters["@Название"].Value = название;
            cmdInsTempl.Parameters["@Примечание"].Value = примечание;
            cmdInsTempl.ExecuteNonQuery();
            return id;
        }
        public Форма[] НайтиФормы(string форма)
        {
            cmdSelFormByHash.Parameters["@Хэш"].Value = HashFunc(форма);
            OleDbDataReader reader = cmdSelFormByHash.ExecuteReader();
            ArrayList arrFormId = new ArrayList();
            ArrayList res = new ArrayList();
            while (reader.Read())
                arrFormId.Add((int)reader["КодФормы"]);
            reader.Close();
            foreach (int id in arrFormId)
            {
                cmdGetWordByFormId.Parameters["@КодФормы"].Value = id;
                string s = (string)cmdGetWordByFormId.ExecuteScalar();
                if (форма == s)
                {
                    cmdSelFormById.Parameters["@КодФормы"].Value = id;
                    reader = cmdSelFormById.ExecuteReader();
                    reader.Read();
                    int кодНачФормы = (int)reader["КодНачФормы"];
                    ЧастьРечи чр = (ЧастьРечи)(int)(byte)reader["ЧастьРечи"];
                    int кодПостПризн = (int)reader["КодПостПризн"];
                    int кодИзмПризн = (int)reader["КодИзмПризн"];
                    string осн1 = (string)reader["Основа1"];
                    string осн2 = (string)reader["Основа2"];
                    string осн3 = (string)reader["Основа3"];
                    string оконч1 = (string)reader["Оконч1"];
                    string оконч2 = (string)reader["Оконч2"];
                    string оконч3 = (string)reader["Оконч3"];
                    reader.Close();
                    bool isНачФорма = false;
                    if (id == кодНачФормы)
                        isНачФорма = true;                    
                    cmdGetWordByFormId.Parameters["@КодФормы"].Value = кодНачФормы;
                    string начФорма = (string)cmdGetWordByFormId.ExecuteScalar();
                    Форма f = new Форма(форма, начФорма, чр,
                        кодПостПризн, кодИзмПризн,
                        осн1, осн2, осн3, оконч1, оконч2, оконч3, isНачФорма);
                    res.Add(f);
                }
            }
            return (Форма[])res.ToArray(typeof(Форма));
        }
        public ФормОконч[] НайтиОкончания(int кодПостПризн,
            int кодИзмПризн, ЧастьРечи частьРечи,
            string основа1, string основа2, string основа3)
        {
            ArrayList res = new ArrayList();
            cmdSelEndByAttr.Parameters["@ЧастьРечи"].Value = (byte)частьРечи;
            cmdSelEndByAttr.Parameters["@КодПостПризн"].Value = кодПостПризн;
            cmdSelEndByAttr.Parameters["@КодИзмПризн"].Value = кодИзмПризн;
            OleDbDataReader reader = cmdSelEndByAttr.ExecuteReader();
            while (reader.Read())
            {
                int кодОконч = (int)reader.GetValue(0);
                string оконч1 = (string)reader.GetValue(1);
                string оконч2 = (string)reader.GetValue(2);
                string оконч3 = (string)reader.GetValue(3);
                string форма = основа1 + оконч1 + основа2 + оконч2 + основа3 + оконч3;
                res.Add(new ФормОконч(кодОконч, оконч1, оконч2, оконч3, форма));
            }
            reader.Close();
            return (ФормОконч[])res.ToArray(typeof(ФормОконч));
        }
        static int HashFunc(string s)
        {
            if (s == null || s == string.Empty)
                return 0;
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
                sum += s[i] * s[i];
            return sum;
        }
    }
}