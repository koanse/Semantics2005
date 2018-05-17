using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SolarixGrammarEngineNET;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SemanticsNew
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //SyntaxAnalysis sa = new SyntaxAnalysis("dictionary.xml", true, true, 2);
            //bool x = sa.CheckSyn("человек", "студент");
            //x = sa.CheckSyn("книжка", "разговор");
            /*IntPtr hEngine = GrammarEngine.sol_CreateGrammarEngineW("dictionary.xml");
            Int32 r = GrammarEngine.sol_DictionaryVersion(hEngine);
            if (r != -1)
            {
                MessageBox.Show("Словарь загружен. Версия: " + r.ToString());
            }
            else
            {
                MessageBox.Show("Ошибка загрузки словаря.");
                return;
            }

            // Проверим, что там есть русский лексикон.
            int ie1 = GrammarEngine.sol_FindEntry(hEngine, "МАМА",
                SolarixGrammarEngineNET.GrammarEngineAPI.NOUN_ru,
                SolarixGrammarEngineNET.GrammarEngineAPI.RUSSIAN_LANGUAGE);
            if (ie1 == -1)
            {
                MessageBox.Show("Russian language is missing in lexicon.");
                return;
            }


            
            IntPtr hCoord = GrammarEngine.sol_ProjectWord(hEngine, "ИГРАВ", true);
            int projCount = GrammarEngine.sol_CountProjections(hCoord);
            int ie = GrammarEngine.sol_GetIEntry(hCoord, 0);
            int ie2 = GrammarEngine.sol_TranslateToInfinitive(hEngine, ie);

            int eClass = GrammarEngine.sol_GetEntryClass(hEngine, ie);
            int gender = GrammarEngine.sol_GetProjCoordState(hEngine,
                hCoord, 0, SolarixGrammarEngineNET.GrammarEngineAPI.GENDER_ru);
            int form = GrammarEngine.sol_GetProjCoordState(hEngine,
                hCoord, 0, SolarixGrammarEngineNET.GrammarEngineAPI.GERUND_2_ru);
            GrammarEngine.sol_DeleteGrammarEngine(hEngine);
            */
            //SyntaxAnalysis sa = new SyntaxAnalysis("dictionary.xml");
            //STNode[] arrNode = sa.Analize("пила лежит на столе");
        }
    }
    [Serializable]
    public class Word : ICloneable
    {
        protected static Linearizer lin = new Linearizer(new int[] { 12, // кол. частей речи
            Enum.GetValues(typeof(Gender)).Length,
            Enum.GetValues(typeof(Number)).Length,
            Enum.GetValues(typeof(Case)).Length,
            Enum.GetValues(typeof(Animative)).Length,
            Enum.GetValues(typeof(Degree)).Length,
            Enum.GetValues(typeof(Short)).Length,
            Enum.GetValues(typeof(Aspect)).Length,
            Enum.GetValues(typeof(Transitive)).Length,
            Enum.GetValues(typeof(Tense)).Length,
            Enum.GetValues(typeof(Person)).Length });
        protected static Linearizer linPerm = new Linearizer(new int[] { 12,
            Enum.GetValues(typeof(Gender)).Length,
            Enum.GetValues(typeof(Animative)).Length,
            Enum.GetValues(typeof(Aspect)).Length,
            Enum.GetValues(typeof(Transitive)).Length });
        protected static Linearizer linVar = new Linearizer(new int[] { 12,
            Enum.GetValues(typeof(Gender)).Length,
            Enum.GetValues(typeof(Number)).Length,
            Enum.GetValues(typeof(Case)).Length,
            Enum.GetValues(typeof(Degree)).Length,
            Enum.GetValues(typeof(Short)).Length,
            Enum.GetValues(typeof(Tense)).Length,
            Enum.GetValues(typeof(Person)).Length });
        protected int pCode, fCode, vCode;  // код пост., всех и изм. призн.
        public string word, initial;
        public double[] GetParams()
        {
            return null;
        }
        public string GetReport()
        {
            return "no report";
        }
        public bool MorphEquals(Word w) // сравн. морф. хар.
        {
            if (fCode == w.fCode)
                return true;
            return false;
        }
        public bool PermMorphEquals(Word w) // сравн. пост. морф. призн.
        {
            if (pCode == w.pCode)
                return true;
            return false;
        }
        public int CompareMorph(Word w)
        {
            return fCode.CompareTo(w.fCode);
        }
        public int ComparePermMorph(Word w)
        {
            return pCode.CompareTo(w.pCode);
        }
        public int CompareVarMorph(Word w)
        {
            return vCode.CompareTo(w.vCode);
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}]", word, initial);
        }
        protected string GenderToString(Gender gen)
        {
            switch (gen)
            {
                case Gender.Mas:
                    return "МУЖ";
                case Gender.Fem:
                    return "ЖЕН";
                case Gender.Neu:
                    return "СР";
            }
            return "";
        }
        protected string NumberToString(Number numb)
        {
            switch (numb)
            {
                case Number.Sing:
                    return "ЕД";
                case Number.Plur:
                    return "МН";
            }
            return "";
        }
        protected string CaseToString(Case cas)
        {
            switch (cas)
            {
                case Case.Nom:
                    return "ИМ";
                case Case.Gen:
                    return "РОД";
                case Case.Dat:
                    return "ДАТ";
                case Case.Acc:
                    return "ВИН";
                case Case.Inst:
                    return "ТВ";
                case Case.Prep:
                    return "ПР";                
            }
            return "";
        }
        protected string AnimativeToString(Animative anim)
        {
            switch (anim)
            {
                case Animative.Anim:
                    return "ОДУШ";
                case Animative.Inan:
                    return "НЕОДУШ";
            }
            return "";
        }
        protected string DegreeToString(Degree deg)
        {
            switch (deg)
            {
                case Degree.Attr:
                    return "АТТР";
                case Degree.Comp:
                    return "СРАВ";
                case Degree.Sup:
                    return "ПРЕВ";
            }
            return "";
        }
        protected string ShortToString(Short sh)
        {
            switch (sh)
            {
                case Short.Ful:
                    return "ПОЛН";
                case Short.Sh:
                    return "КРАТК";
            }
            return "";
        }
        protected string AspectToString(Aspect asp)
        {
            switch (asp)
            {
                case Aspect.Imp:
                    return "НЕСОВ";
                case Aspect.Per:
                    return "СОВ";
            }
            return "";
        }
        protected string TransitiveToString(Transitive tr)
        {
            switch (tr)
            {
                case Transitive.Tran:
                    return "ПЕРЕХ";
                case Transitive.Intr:
                    return "НЕПЕРЕХ";
            }
            return "";
        }
        protected string TenseToString(Tense ten)
        {
            switch (ten)
            {
                case Tense.Pst:
                    return "ПРОШ";
                case Tense.Pre:
                    return "НАСТ";
                case Tense.Fut:
                    return "БУД";
            }
            return "";
        }
        protected string PersonToString(Person per)
        {
            switch (per)
            {
                case Person.Fir:
                    return "1Л";
                case Person.Sec:
                    return "2Л";
                case Person.Thrd:
                    return "3Л";
            }
            return "";
        }
        public virtual object Clone()
        {
            throw new Exception();
        }
    }
    [Serializable]
    public class Noun : Word
    {
        Gender gen;
        Number numb;
        Case cas;
        Animative anim;
        public Noun(string word, string initial,
            Gender gen, Number numb, Case cas, Animative anim)
        {
            this.word = word;
            this.initial = initial;
            this.gen = gen;
            this.numb = numb;
            this.cas = cas;
            this.anim = anim;
            fCode = lin.GetIndex(new int[] { 0,
                (int)gen, (int)numb, (int)cas, (int)anim,
                0, 0, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 0,
                (int)gen, (int)anim, 0, 0 });
            vCode = linVar.GetIndex(new int[] {0,
                0, (int)numb, (int)cas, 0, 0, 0, 0 });
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2} {3} {4} {5}]", word, initial,
                GenderToString(gen), NumberToString(numb),
                CaseToString(cas), AnimativeToString(anim));
        }
        public override object Clone()
        {
            return new Noun(word, initial, gen, numb, cas, anim);
        }
    }
    [Serializable]
    public class Adjective : Word
    {
        Gender gen;
        Number numb;
        Case cas;
        Degree deg;
        Short sh;
        public Adjective(string word, string initial,
            Gender gen, Number numb, Case cas,
            Degree deg, Short sh)
        {
            this.word = word;
            this.initial = initial;
            this.gen = gen;
            this.numb = numb;
            this.cas = cas;
            this.deg = deg;
            this.sh = sh;
            fCode = lin.GetIndex(new int[] { 1,
                (int)gen, (int)numb, (int)cas, 0, (int)deg,
                (int)sh, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 1,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 1,
                (int)gen, (int)numb, (int)cas, (int)deg, (int)sh, 0, 0 });
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2} {3} {4} {5} {6}]", word, initial,
                GenderToString(gen), NumberToString(numb), CaseToString(cas),
                DegreeToString(deg), ShortToString(sh));
        }
        public override object Clone()
        {
            return new Adjective(word, initial, gen, numb, cas, deg, sh);
        }
    }
    [Serializable]
    public class Numeral : Word
    {
        Gender gen;
        Number numb;
        Case cas;
        public Numeral(string word, string initial,
            Gender gen, Number numb, Case cas)
        {
            this.word = word;
            this.initial = initial;
            this.gen = gen;
            this.numb = numb;
            this.cas = cas;
            fCode = lin.GetIndex(new int[] { 2,
                (int)gen, (int)numb, (int)cas, 0, 0,
                0, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 2,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 2,
                (int)gen, (int)numb, (int)cas, 0, 0, 0, 0 });
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2} {3} {4}]", word, initial,
                GenderToString(gen), NumberToString(numb), CaseToString(cas));
        }
        public override object Clone()
        {
            return new Numeral(word, initial, gen, numb, cas);
        }
    }
    [Serializable]
    public class Verb : Word
    {
        Aspect asp;
        Transitive tr;
        Tense ten;
        Gender gen;
        Number numb;
        Person per;

        public Verb(string word, string initial,
            Aspect asp, Transitive tr, Tense ten,
            Gender gen, Number numb, Person per)
        {
            this.word = word;
            this.initial = initial;
            this.asp = asp;
            this.tr = tr;
            this.ten = ten;
            this.gen = gen;
            this.numb = numb;
            this.per = per;
            fCode = lin.GetIndex(new int[] { 3,
                (int)gen, (int)numb, 0, 0, 0,
                0, (int)asp, (int)tr, (int)ten, (int)per });
            pCode = linPerm.GetIndex(new int[] { 3,
                0, 0, (int)asp, (int)tr });
            vCode = linVar.GetIndex(new int[] { 3,
                (int)gen, (int)numb, 0, 0, 0, (int)ten, (int)per });
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2} {3} {4} {5} {6} {7}]", word, initial,
                AspectToString(asp), TransitiveToString(tr), TenseToString(ten),
                GenderToString(gen), NumberToString(numb), PersonToString(per));
        }
        public override object Clone()
        {
            return new Verb(word, initial, asp, tr, ten, gen, numb, per);
        }
    }
    [Serializable]
    public class Participle : Word
    {
        Aspect asp;
        Transitive tr;
        Gender gen;
        Number numb;
        Case cas;
        Degree deg;
        Short sh;

        public Participle(string word, string initial,
            Aspect asp, Transitive tr, Gender gen,
            Number numb, Case cas, Degree deg, Short sh)
        {
            this.word = word;
            this.initial = initial;
            this.asp = asp;
            this.tr = tr;
            this.gen = gen;
            this.numb = numb;
            this.cas = cas;
            this.deg = deg;
            this.sh = sh;
            fCode = lin.GetIndex(new int[] { 4,
                (int)gen, (int)numb, (int)cas, 0, (int)deg,
                (int)sh, (int)asp, (int)tr, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 4,
                0, 0, (int)asp, (int)tr });
            vCode = linVar.GetIndex(new int[] { 4,
                (int)gen, (int)numb, (int)cas, (int)deg, (int)sh, 0, 0 });
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2} {3} {4} {5} {6} {7} {8}]", word, initial,
                AspectToString(asp), TransitiveToString(tr), GenderToString(gen),
                NumberToString(numb), CaseToString(cas), DegreeToString(deg),
                ShortToString(sh));
        }
        public override object Clone()
        {
            return new Participle(word, initial, asp, tr, gen, numb, cas, deg, sh);
        }
    }
    [Serializable]
    public class AdvParticiple : Word
    {
        Aspect asp;
        Transitive tr;
        public AdvParticiple(string word, string initial,
            Aspect asp, Transitive tr)
        {
            this.word = word;
            this.initial = initial;
            this.asp = asp;
            this.tr = tr;
            fCode = lin.GetIndex(new int[] { 5,
                0, 0, 0, 0, 0,
                0, (int)asp, (int)tr, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 5,
                0, 0, (int)asp, (int)tr });
            vCode = linVar.GetIndex(new int[] { 5,
                0, 0, 0, 0, 0, 0, 0 });
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2} {3}]", word, initial,
                AspectToString(asp), TransitiveToString(tr));
        }
        public override object Clone()
        {
            return new AdvParticiple(word, initial, asp, tr);
        }
    }
    [Serializable]
    public class Adverb : Word
    {
        Degree deg;
        public Adverb(string word, string initial, Degree deg)
        {
            this.word = word;
            this.initial = initial;
            this.deg = deg;
            fCode = lin.GetIndex(new int[] { 6,
                0, 0, 0, 0, (int)deg,
                0, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 6,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 6,
                0, 0, 0, (int)deg, 0, 0, 0 });
        }        
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2}]", word, initial, DegreeToString(deg));
        }
        public override object Clone()
        {
            return new Adverb(word, initial, deg);
        }
    }
    [Serializable]
    public class Conjunction : Word
    {
        public Conjunction(string word, string initial)
        {
            this.word = word;
            this.initial = initial;
            fCode = lin.GetIndex(new int[] { 7,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 7,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 7,
                0, 0, 0, 0, 0, 0, 0 });
        }
        public override object Clone()
        {
            return new Conjunction(word, initial);
        }
    }
    [Serializable]
    public class Preposition : Word
    {
        public Preposition(string word, string initial)
        {
            this.word = word;
            this.initial = initial;
            fCode = lin.GetIndex(new int[] { 8,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 8,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 8,
                0, 0, 0, 0, 0, 0, 0 });
        }
        public override object Clone()
        {
            return new Preposition(word, initial);
        }
    }
    [Serializable]
    public class Particle : Word
    {
        public Particle(string word, string initial)
        {
            this.word = word;
            this.initial = initial;
            fCode = lin.GetIndex(new int[] { 9,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 9,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 9,
                0, 0, 0, 0, 0, 0, 0 });
        }
        public override object Clone()
        {
            return new Particle(word, initial);
        }
    }
    [Serializable]
    public class Pronoun : Word
    {
        Gender gen;
        Number numb;
        Case cas;
        Person per;
        public Pronoun(string word, string initial,
            Gender gen, Number numb, Case cas, Person per)
        {
            this.word = word;
            this.initial = initial;
            this.gen = gen;
            this.numb = numb;
            this.cas = cas;
            this.per = per;
            fCode = lin.GetIndex(new int[] { 10,
                (int)gen, (int)numb, (int)cas, 0, 0,
                0, 0, 0, 0, (int)per });
            pCode = linPerm.GetIndex(new int[] { 10,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 10,
                (int)gen, (int)numb, (int)cas, 0, 0, 0, 0 });
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}: {2} {3} {4} {5}]", word, initial,
                GenderToString(gen), NumberToString(numb), CaseToString(cas),
                PersonToString(per));
        }
        public override object Clone()
        {
            return new Pronoun(word, initial, gen, numb, cas, per);
        }
    }
    [Serializable]
    public class Punctuation : Word
    {
        public Punctuation(string word)
        {
            this.word = word;
            this.initial = word;
            fCode = lin.GetIndex(new int[] { 11,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            pCode = linPerm.GetIndex(new int[] { 11,
                0, 0, 0, 0 });
            vCode = linVar.GetIndex(new int[] { 11,
                0, 0, 0, 0, 0, 0, 0 });
        }
        public override object Clone()
        {
            return new Punctuation(word);
        }
    }

    [Serializable]
    public class STNode : ICloneable
    {
        public Word word;
        public STNode parent;
        public STNode[] arrChild;
        public Actant actant;
        public STNode(Word word, STNode parent)
        {
            this.word = word;
            this.parent = parent;
        }
        public object Clone()
        {
            STNode nd = new STNode((Word)word.Clone(), parent);
            nd.actant = actant;
            return nd;
        }
        public static STNode[] GetChildren(STNode start) // возвр. ближ. потомок(и) по ветке, игнор. част., предл. и т.д.
        {
            if (start.word.GetType() != typeof(Conjunction) &&
                start.word.GetType() != typeof(Preposition) &&
                start.word.GetType() != typeof(Particle) &&
                start.word.GetType() != typeof(Punctuation))
                return new STNode[] { start };
            if (start.arrChild == null)
                return null;
            if (start.word.initial == "И")
                return (STNode[])start.arrChild.Clone();
            if (start.arrChild.Length > 1)
                return null;    // однор. чл. могут соединяться только "И"
            return GetChildren(start.arrChild[0]);
        }
        public static List<STNode> GetDescendants(STNode root) // все потомки (а также root), кроме част., предл. ...
        {
            List<STNode> listNode = new List<STNode>();
            if (root.word.GetType() != typeof(Conjunction) &&
                root.word.GetType() != typeof(Preposition) &&
                root.word.GetType() != typeof(Particle) &&
                root.word.GetType() != typeof(Punctuation))
                listNode.Add(root);
            if (root.arrChild == null)
                return listNode;
            foreach (STNode nd in root.arrChild)
                listNode.AddRange(STNode.GetDescendants(nd));
            return listNode;
        }
        public static List<STNode> GetDescendants(STNode[] arrRoot)
        {
            List<STNode> listNode = new List<STNode>();
            foreach (STNode root in arrRoot)
                listNode.AddRange(STNode.GetDescendants(root));
            return listNode;
        }
        public static STNode GetParent(STNode start) // аргумент - непоср. родитель, возвр. родитель (не част., предл. ...)
        {
            if (start == null ||
                start.word.GetType() != typeof(Conjunction) &&
                start.word.GetType() != typeof(Preposition) &&
                start.word.GetType() != typeof(Particle) &&
                start.word.GetType() != typeof(Punctuation))
                return start;
            return GetParent(start.parent);
        }
        public static double GetNegation(STNode nd) // подсчет кол. "не", возвр. -1 или 1
        {
            if (nd == null ||
                nd.word.GetType() != typeof(Conjunction) &&
                nd.word.GetType() != typeof(Preposition) &&
                nd.word.GetType() != typeof(Particle) &&
                nd.word.GetType() != typeof(Punctuation))
                return 1;
            if (nd.word.initial == "НЕ")
                return -GetNegation(nd.parent);
            if (nd.parent == null)
                return 1;
            return GetNegation(nd.parent);
        }
        public static string GetConnector(STNode start)
        {
            string s = "";
            while (true)
            {
                if ((start.word.GetType() != typeof(Conjunction) &&
                    start.word.GetType() != typeof(Preposition) &&
                    start.word.GetType() != typeof(Particle) &&
                    start.word.GetType() != typeof(Punctuation)) ||
                    start.arrChild == null)
                    return s;
                if (start.word.initial != "НЕ" &&
                    start.word.initial != "НИ" &&
                    start.word.initial != "И")
                    if (s == "")
                        s += start.word.initial;
                    else
                        s += " " + start.word.initial;
                start = start.arrChild[0];
            }
        }
        public static STNode CloneSubTree(STNode root, STNode parent)
        {
            STNode nd = (STNode)root.Clone();
            nd.parent = parent;
            if (root.arrChild == null)
                return nd;
            nd.arrChild = new STNode[root.arrChild.Length];
            for (int i = 0; i < nd.arrChild.Length; i++)
                nd.arrChild[i] = CloneSubTree(root.arrChild[i], nd);
            return nd;
        }
        public override string ToString()
        {
            return string.Format("{0}, Актант:{1}", word, actant);
        }
    }    
    public class SyntaxAnalysis
    {
        IntPtr hEngine;
        bool allowDynForms = false, allowUnknown = false;
        int jumpCount = 2;
        public SyntaxAnalysis(string dictionary,
            bool allowDynForms, bool allowUnknown, int jumpCount)
        {
            this.allowDynForms = allowDynForms;
            this.allowUnknown = allowUnknown;
            this.jumpCount = jumpCount;
            hEngine = GrammarEngine.sol_CreateGrammarEngineW(dictionary);            
        }
        public STNode[] Analize(string phrase)  // возвр. массив корней
        {
            IntPtr hPack = GrammarEngine.sol_SyntaxAnalysis(hEngine,
                phrase, allowDynForms, allowUnknown);
            int gCount = GrammarEngine.sol_CountGrafs(hPack);
            int gIndex = -1, min = int.MaxValue;
            for (int i = 0; i < gCount; i++)
            {
                int rCount = GrammarEngine.sol_CountRoots(hPack, i);
                if (rCount < min)
                {
                    min = rCount;
                    gIndex = i;
                }
            }

            STNode[] arrNode = new STNode[min - 2];
            for (int i = 1; i < min - 1; i++)
            {
                IntPtr hNode = GrammarEngine.sol_GetRoot(hPack, gIndex, i);
                arrNode[i - 1] = CreateNode(hNode, null);
                FindHomogens(arrNode[i - 1]);
            }
            GrammarEngine.sol_DeleteResPack(hPack);
            return arrNode;
        }
        public TreeNode[] CreateTreeNodes(STNode[] arrRoot)
        {
            TreeNode[] arrNode = new TreeNode[arrRoot.Length];
            for (int i = 0; i < arrNode.Length; i++)
                arrNode[i] = CreateTreeNode(arrRoot[i]);
            return arrNode;
        }
        public GovPattern[] GetGovPatterns(STNode[] arrRoot, GPDictionary gpDict)
        {
            List<GovPattern> listGp = new List<GovPattern>();
            foreach (STNode nd in arrRoot)
                listGp.AddRange(GetNodeGovPatterns(nd, gpDict));
            return listGp.ToArray();
        }
        public void SetActants(STNode[] arrRoot, GPDictionary gpDict)
        {
            foreach (STNode nd in arrRoot)
                SetActants(nd, gpDict);
        }
        public bool CheckSyn(string wX, string wY)
        {
            IntPtr hCoordX = GrammarEngine.sol_ProjectWord(hEngine, wX, allowDynForms);
            int pCountX = GrammarEngine.sol_CountProjections(hCoordX);
            IntPtr hCoordY = GrammarEngine.sol_ProjectWord(hEngine, wY, allowDynForms);
            int pCountY = GrammarEngine.sol_CountProjections(hCoordY);
            for (int i = 0; i < pCountX; i++)
            {
                int eIndexX = GrammarEngine.sol_GetIEntry(hCoordX, i);
                int eClassX = GrammarEngine.sol_GetEntryClass(hEngine, eIndexX);
                for (int j = 0; j < pCountY; j++)
                {
                    int eIndexY = GrammarEngine.sol_GetIEntry(hCoordY, j);
                    int eClassY = GrammarEngine.sol_GetEntryClass(hEngine, eIndexY);
                    if (eClassX != eClassY)
                        break;
                    IntPtr hLink = GrammarEngine.sol_SeekThesaurus(hEngine, eIndexY,
                        true, false, false, true, jumpCount);
                    if (hLink.ToInt32() != 0)
                    {
                        int linkCount = GrammarEngine.sol_CountInts(hLink);
                        if (linkCount > 0)
                        {
                            for (int k = 0; k < linkCount; k++)
                                if (GrammarEngine.sol_GetInt(hLink, k) == eIndexX)
                                    return true;
                            GrammarEngine.sol_DeleteInts(hLink);
                        }
                    }
                }
            }
            return false;
        }
        public bool CheckDer(string wX, string wY)
        {
            IntPtr hCoordX = GrammarEngine.sol_ProjectWord(hEngine, wX, allowDynForms);
            int pCountX = GrammarEngine.sol_CountProjections(hCoordX);
            IntPtr hCoordY = GrammarEngine.sol_ProjectWord(hEngine, wY, allowDynForms);
            int pCountY = GrammarEngine.sol_CountProjections(hCoordY);
            for (int i = 0; i < pCountX; i++)
            {
                int eIndexX = GrammarEngine.sol_GetIEntry(hCoordX, i);
                int eClassX = GrammarEngine.sol_GetEntryClass(hEngine, eIndexX);
                for (int j = 0; j < pCountY; j++)
                {
                    int eIndexY = GrammarEngine.sol_GetIEntry(hCoordY, j);
                    int eClassY = GrammarEngine.sol_GetEntryClass(hEngine, eIndexY);
                    if (eClassX == eClassY)
                        break;
                    IntPtr hLink = GrammarEngine.sol_SeekThesaurus(hEngine, eIndexY,
                        false, false, true, false, jumpCount);
                    if (hLink.ToInt32() != 0)
                    {
                        int linkCount = GrammarEngine.sol_CountInts(hLink);
                        if (linkCount > 0)
                        {
                            for (int k = 0; k < linkCount; k++)
                                if (GrammarEngine.sol_GetInt(hLink, k) == eIndexX)
                                    return true;
                            GrammarEngine.sol_DeleteInts(hLink);
                        }
                    }
                }
            }
            return false;
        }
        public void RemovePrepositions(STNode[] arrRoot)
        {
            foreach (STNode root in arrRoot)
                RemovePrep(root);
        }
        void RemovePrep(STNode root)
        {
            if (root.word.GetType() == typeof(Preposition))
            {
                List<STNode> listChild = new List<STNode>();
                if (root.parent != null)
                    listChild.AddRange(root.parent.arrChild);
                listChild.Remove(root);
                listChild.AddRange(root.arrChild);
                root.parent.arrChild = listChild.ToArray();
                if (root.arrChild != null)
                    foreach (STNode child in root.arrChild)
                        child.parent = root.parent;
            }
            if (root.arrChild != null)
                foreach (STNode child in root.arrChild)
                    RemovePrep(child);
        }
        void FindHomogens(STNode nd) // определение общих зависимых для одн. членов
        {
            if (nd.arrChild == null)
                return;
            foreach (STNode ndChild in nd.arrChild)
                FindHomogens(ndChild);
            if (nd.word.initial != "И")
                return;
            STNode[][] arrArrChild = new STNode[nd.arrChild.Length][];
            for (int i = 0; i < nd.arrChild.Length; i++)
                arrArrChild[i] = STNode.GetChildren(nd.arrChild[i]);
            Word wHomo = null;
            for (int i = 0; i < arrArrChild.Length; i++)
                for (int j = 0; j < i; j++)
                    if (arrArrChild[i] != null && arrArrChild[j] != null &&
                        arrArrChild[i][0].word.CompareVarMorph(
                        arrArrChild[j][0].word) == 0)
                    {
                        wHomo = arrArrChild[i][0].word;
                        break;
                    }
            if (wHomo == null)
                return;
            List<int> listIndexHomo = new List<int>();
            List<int> listIndexNotHomo = new List<int>();
            for (int i = 0; i < arrArrChild.Length; i++)
                if (arrArrChild[i][0].word.CompareVarMorph(wHomo) == 0)
                    listIndexHomo.Add(i);
                else
                    listIndexNotHomo.Add(i);
            foreach (int i in listIndexHomo)
                foreach (STNode ndHomo in arrArrChild[i])
                {
                    List<STNode> listChild = new List<STNode>();
                    foreach (int j in listIndexNotHomo)
                    {
                        STNode ndClone = STNode.CloneSubTree(nd.arrChild[j], ndHomo);
                        listChild.Add(ndClone);
                    }
                    if (ndHomo.arrChild != null)
                        listChild.AddRange(ndHomo.arrChild);
                    if (listChild.Count > 0)
                        ndHomo.arrChild = listChild.ToArray();
                    else
                        ndHomo.arrChild = null;
                }
            List<STNode> listNdChild = new List<STNode>();
            foreach (int i in listIndexHomo)
                listNdChild.Add(nd.arrChild[i]);
            nd.arrChild = listNdChild.ToArray();
        }
        void SetActants(STNode parent, GPDictionary gpDict)
        {
            if (parent.arrChild == null)
                return;
            foreach (STNode ndChild in parent.arrChild)
                SetActants(ndChild, gpDict);
            if (parent.word.GetType() == typeof(Conjunction) ||
                parent.word.GetType() == typeof(Preposition) ||
                parent.word.GetType() == typeof(Particle) ||
                parent.word.GetType() == typeof(Punctuation))
                return;
            STNode[][] arrArrChild = new STNode[parent.arrChild.Length][];
            string[] arrConn = new string[parent.arrChild.Length];
            int rowCount = 0;
            for (int i = 0; i < arrArrChild.Length; i++)
            {
                arrArrChild[i] = STNode.GetChildren(parent.arrChild[i]);
                if (arrArrChild[i] != null)
                    rowCount++;
                arrConn[i] = STNode.GetConnector(parent.arrChild[i]);
            }
            if (rowCount == 0)
                return;
            int colCount = Enum.GetValues(typeof(Actant)).Length - 2 + rowCount;
            double[,] matr = new double[colCount, colCount];
            int rowIndex = 0;
            for (int i = 0; i < arrArrChild.Length; i++)
            {
                if (arrArrChild[i] == null)
                    continue;
                double[] arrP = gpDict.GetProbabilities(parent.word,
                    arrArrChild[i][0].word, arrConn[i]);
                for (int j = 0; j < arrP.Length; j++)
                    matr[rowIndex, j] = arrP[j];
                for (int j = arrP.Length; j < colCount; j++)
                    matr[rowIndex, j] = arrP[arrP.Length - 1];
                rowIndex++;
            }
            while (rowIndex < colCount)
            {
                for (int j = 0; j < colCount; j++)
                    matr[rowIndex, j] = 0;
                rowIndex++;
            }
            MackMethod mm = new MackMethod(matr);
            while (mm.DoIteration()) ;
            int[] arrIndex = mm.GetResultIndexes();
            rowIndex = 0;
            for (int i = 0; i < arrArrChild.Length; i++)
            {
                if (arrArrChild[i] == null)
                    continue;
                Actant actant;
                if (arrIndex[rowIndex] + 1 >= Enum.GetValues(typeof(Actant)).Length)
                    actant = Actant.Attribute;
                else
                    actant = (Actant)arrIndex[rowIndex] + 1;
                foreach (STNode nd in arrArrChild[i])
                    nd.actant = actant;
                rowIndex++;
            }
        }
        TreeNode CreateTreeNode(STNode nd)
        {
            TreeNode tn = new TreeNode(nd.ToString());
            if (nd.arrChild != null)
                foreach (STNode ndChild in nd.arrChild)
                    tn.Nodes.Add(CreateTreeNode(ndChild));
            return tn;
        }
        STNode CreateNode(IntPtr hNode, STNode parent)
        {
            Word[] arrWord = GetNodeWords(hNode);
            STNode[] arrNode = new STNode[arrWord.Length];
            for (int i = 0; i < arrNode.Length; i++)
                if (i == 0)
                    arrNode[i] = new STNode(arrWord[i], parent);
                else
                    arrNode[i] = new STNode(arrWord[i], arrNode[i - 1]);
            for (int i = 0; i < arrNode.Length - 1; i++)
                arrNode[i].arrChild = new STNode[] { arrNode[i + 1] };

            int lCount = GrammarEngine.sol_CountLeafs(hNode);
            if (lCount > 0)
            {
                STNode nd = arrNode[arrNode.Length - 1];
                nd.arrChild = new STNode[lCount];
                for (int i = 0; i < lCount; i++)
                {
                    IntPtr hNodeChild = GrammarEngine.sol_GetLeaf(hNode, i);
                    nd.arrChild[i] = CreateNode(hNodeChild, nd);
                }
            }
            return arrNode[0];
        }
        Word[] GetNodeWords(IntPtr hNode)
        {
            StringBuilder sb = new StringBuilder();
            GrammarEngine.sol_GetNodeContents(hNode, sb);
            string contents = sb.ToString();
            if (contents.Contains("_"))
                contents = contents.Substring(contents.IndexOf('_') + 1);
            IntPtr hTokens = GrammarEngine.sol_Tokenize(hEngine, contents);
            int tokCount = GrammarEngine.sol_CountStrings(hTokens);
            Word[] arrWord = new Word[tokCount];
            for (int i = 0; i < tokCount; i++)
            {
                int eIndex = -1;
                if (i == tokCount - 1)
                    eIndex = GrammarEngine.sol_GetNodeIEntry(hEngine, hNode);
                GrammarEngine.sol_GetString(hTokens, i, sb);
                string word = sb.ToString();
                if (word.Contains("_"))
                    word = word.Substring(word.IndexOf('_') + 1);
                arrWord[i] = WordFactory(word, eIndex);
            }
            return arrWord;
        }
        GovPattern[] GetNodeGovPatterns(STNode nd, GPDictionary gpDict)
        {
            List<GovPattern> listGp = new List<GovPattern>();
            if (nd.arrChild != null)
                foreach (STNode ndChild in nd.arrChild)
                    listGp.AddRange(GetNodeGovPatterns(ndChild, gpDict));
            if (nd.word.GetType() == typeof(Conjunction) ||
                nd.word.GetType() == typeof(Preposition) ||
                nd.word.GetType() == typeof(Particle) ||
                nd.word.GetType() == typeof(Punctuation) ||
                nd.arrChild == null)
                return listGp.ToArray();
            foreach (STNode ndChild in nd.arrChild)
            {
                STNode[] arrChild = STNode.GetChildren(ndChild);
                string connector = STNode.GetConnector(ndChild);
                for (int i = 0; i < arrChild.Length; i++)
                    if (gpDict.GetActant(nd.word, arrChild[i].word,
                        connector) == Actant.Undef)
                        listGp.Add(new GovPattern(nd.word, arrChild[i].word,
                            arrChild[i].actant, connector));
            }
            return listGp.ToArray();
        }
        Word WordFactory(string word, int eIndex)   // если индекс записи неизв., то eIndex = -1
        {
            IntPtr hCoord = GrammarEngine.sol_ProjectWord(hEngine, word, allowDynForms);
            int projCount = GrammarEngine.sol_CountProjections(hCoord);
            int i = 0;
            if (eIndex != -1)
                for (; i < projCount; i++)
                {
                    int ei = GrammarEngine.sol_GetIEntry(hCoord, i);
                    if (ei == eIndex)
                        break;
                }
            if (eIndex == -1 || i == projCount)
            {
                i = 0;
                eIndex = GrammarEngine.sol_GetIEntry(hCoord, 0);
            }
            int eClass = GrammarEngine.sol_GetEntryClass(hEngine, eIndex);
            StringBuilder sb = new StringBuilder();
            GrammarEngine.sol_GetEntryName(hEngine, eIndex, sb);
            string initial = sb.ToString();
            if (initial.Contains("_"))
                initial = initial.Substring(0, initial.IndexOf('_'));

            switch (eClass)
            {
                case GrammarEngineAPI.NOUN_ru:
                    int gen = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.GENDER_ru);
                    int numb = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.NUMBER_ru);
                    int cas = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.CASE_ru);
                    int anim = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.FORM_ru);
                    return new Noun(word, initial, GetGender(gen),
                        GetNumber(numb), GetCase(cas), GetAnimative(anim));

                case GrammarEngineAPI.ADJ_ru:
                    gen = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                            i, GrammarEngineAPI.GENDER_ru);
                    numb = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.NUMBER_ru);
                    cas = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.CASE_ru);
                    int deg = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.COMPAR_FORM_ru);
                    int sh = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.SHORTNESS_ru);
                    int participle = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.PARTICIPLE_ru);
                    if (participle != 1)    // прил.
                        return new Adjective(word, initial, GetGender(gen),
                            GetNumber(numb), GetCase(cas),
                            GetDegree(deg), GetShort(sh));
                    else                    // прич.
                    {
                        int eIndexInf = GrammarEngine.sol_TranslateToInfinitive(hEngine, eIndex);
                        GrammarEngine.sol_GetEntryName(hEngine, eIndexInf, sb);
                        hCoord = GrammarEngine.sol_ProjectWord(hEngine, sb.ToString(),
                            allowDynForms);
                        int aspPrt = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.ASPECT_ru);
                        int trPrt = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                            i, GrammarEngineAPI.TRANSITIVENESS_ru);
                        return new Participle(word, initial, GetAspect(aspPrt),
                            GetTransitive(trPrt), GetGender(gen), GetNumber(numb),
                            GetCase(cas), GetDegree(deg), GetShort(sh));
                    }

                case GrammarEngineAPI.NUMBER_CLASS_ru:
                    gen = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.GENDER_ru);
                    numb = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.NUMBER_ru);
                    cas = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.CASE_ru);
                    return new Numeral(word, initial,
                        GetGender(gen), GetNumber(numb), GetCase(cas));

                case GrammarEngineAPI.INFINITIVE_ru:
                    int asp = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.ASPECT_ru);
                    int tr = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.TRANSITIVENESS_ru);
                    return new Verb(word, initial, GetAspect(asp),
                        GetTransitive(tr), Tense.Undef,
                        Gender.Undef, Number.Undef, Person.Undef);

                case GrammarEngineAPI.VERB_ru:
                    asp = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.ASPECT_ru);
                    tr = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.TRANSITIVENESS_ru);
                    int ten = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.TENSE_ru);
                    gen = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.GENDER_ru);
                    numb = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.NUMBER_ru);
                    int per = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.PERSON_ru);
                    return new Verb(word, initial, GetAspect(asp),
                        GetTransitive(tr), GetTense(ten),
                        GetGender(gen), GetNumber(numb), GetPerson(per));

                case GrammarEngineAPI.GERUND_2_ru:
                    asp = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.ASPECT_ru);
                    tr = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.TRANSITIVENESS_ru);
                    return new AdvParticiple(word, initial,
                        GetAspect(asp), GetTransitive(tr));

                case GrammarEngineAPI.ADVERB_ru:
                    deg = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.COMPAR_FORM_ru);
                    return new Adverb(word, initial, GetDegree(deg));

                case GrammarEngineAPI.CONJ_ru:
                    return new Conjunction(word, initial);

                case GrammarEngineAPI.PREPOS_ru:
                    return new Preposition(word, initial);

                case GrammarEngineAPI.PARTICLE_ru:
                    return new Particle(word, initial);

                case GrammarEngineAPI.PRONOUN_ru:
                    gen = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.GENDER_ru);
                    numb = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.NUMBER_ru);
                    cas = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.CASE_ru);
                    per = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.PERSON_ru);
                    return new Pronoun(word, initial, GetGender(gen),
                        GetNumber(numb), GetCase(cas), GetPerson(per));

                case 8: // мест.-сущ.
                    gen = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.GENDER_ru);
                    numb = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.NUMBER_ru);
                    cas = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.CASE_ru);
                    per = GrammarEngine.sol_GetProjCoordState(hEngine, hCoord,
                        i, GrammarEngineAPI.PERSON_ru);
                    return new Pronoun(word, initial, GetGender(gen),
                        GetNumber(numb), GetCase(cas), GetPerson(per));

                case 22: // знаки пункт.
                    return new Punctuation(word);

                default:
                    throw new Exception();
            }
        }        
        Gender GetGender(int gen)
        {
            switch (gen)
            {
                case GrammarEngineAPI.MASCULINE_GENDER_ru:
                    return Gender.Mas;
                case GrammarEngineAPI.FEMININE_GENDER_ru:
                    return Gender.Fem;
                case GrammarEngineAPI.NEUTRAL_GENDER_ru:
                    return Gender.Neu;
                default:
                    return Gender.Undef;
            }
        }
        Number GetNumber(int numb)
        {
            switch (numb)
            {
                case GrammarEngineAPI.SINGULAR_NUMBER_ru:
                    return Number.Sing;
                case GrammarEngineAPI.PLURAL_NUMBER_ru:
                    return Number.Plur;
                default:
                    return Number.Undef;
            }
        }
        Case GetCase(int cas)
        {
            switch (cas)
            {
                case GrammarEngineAPI.NOMINATIVE_CASE_ru:
                    return Case.Nom;
                case GrammarEngineAPI.GENITIVE_CASE_ru:
                    return Case.Gen;
                case GrammarEngineAPI.DATIVE_CASE_ru:
                    return Case.Dat;
                case GrammarEngineAPI.ACCUSATIVE_CASE_ru:
                    return Case.Acc;
                case GrammarEngineAPI.INSTRUMENTAL_CASE_ru:
                    return Case.Inst;
                case GrammarEngineAPI.PREPOSITIVE_CASE_ru:
                    return Case.Prep;
                default:
                    throw new Exception();
            }
        }
        Animative GetAnimative(int anim)
        {
            switch (anim)
            {
                case GrammarEngineAPI.ANIMATIVE_FORM_ru:
                    return Animative.Anim;
                case GrammarEngineAPI.INANIMATIVE_FORM_ru:
                    return Animative.Inan;
                default:
                    throw new Exception();
            }
        }
        Short GetShort(int sh)
        {
            switch (sh)
            {
                case 0:
                    return Short.Ful;
                case 1:
                    return Short.Sh;
                case -1:
                    return Short.Undef;
                default:
                    throw new Exception();
            }
        }
        Degree GetDegree(int deg)
        {
            switch (deg)
            {
                case GrammarEngineAPI.ATTRIBUTIVE_FORM_ru:
                    return Degree.Attr;
                case GrammarEngineAPI.COMPARATIVE_FORM_ru:
                    return Degree.Comp;
                case GrammarEngineAPI.SUPERLATIVE_FORM_ru:
                    return Degree.Sup;
                case -1:
                    return Degree.Undef;
                default:
                    throw new Exception();
            }
        }
        Aspect GetAspect(int asp)
        {
            switch (asp)
            {
                case GrammarEngineAPI.PERFECT_ru:
                    return Aspect.Per;
                case GrammarEngineAPI.IMPERFECT_ru:
                    return Aspect.Imp;
                default:
                    throw new Exception();
            }
        }
        Transitive GetTransitive(int tr)
        {
            switch (tr)
            {
                case GrammarEngineAPI.TRANSITIVE_VERB_ru:
                    return Transitive.Tran;
                case 0:
                    return Transitive.Intr;
                default:
                    throw new Exception();
            }
        }
        Tense GetTense(int ten)
        {
            switch (ten)
            {
                case GrammarEngineAPI.PAST_ru:
                    return Tense.Pst;
                case GrammarEngineAPI.PRESENT_ru:
                    return Tense.Pre;
                case GrammarEngineAPI.FUTURE_ru:
                    return Tense.Fut;
                default:
                    return Tense.Undef;
            }
        }
        Person GetPerson(int per)
        {
            switch (per)
            {
                case GrammarEngineAPI.PERSON_1_ru:
                    return Person.Fir;
                case GrammarEngineAPI.PERSON_2_ru:
                    return Person.Sec;
                case GrammarEngineAPI.PERSON_3_ru:
                    return Person.Thrd;
                case -1:
                    return Person.Undef;
                default:
                    throw new Exception();
            }
        }
        ~SyntaxAnalysis()
        {
            GrammarEngine.sol_DeleteGrammarEngine(hEngine);
        }
    }
    [Serializable]
    public class GovPattern : IComparable<GovPattern>
    {
        public Word wMain, wActant;
        public Actant actant;
        public string connector;
        public GovPattern(Word wMain, Word wActant, Actant actant,
            string connector)
        {
            this.wMain = wMain;
            this.wActant = wActant;
            this.actant = actant;
            this.connector = connector;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} [Actant:{3}]", wMain.word, connector,
                wActant.word, actant);
        }
        public int CompareTo(GovPattern other)
        {
            int res = wMain.initial.CompareTo(other.wMain.initial);
            if (res != 0)
                return res;            
            res = wMain.ComparePermMorph(other.wMain);
            if (res != 0)
                return res;            
            res = connector.CompareTo(other.connector);
            if (res != 0)
                return res;
            res = wActant.CompareMorph(other.wActant);
            if (res != 0)
                return res;            
            return actant.CompareTo(other.actant);
        }
    }
    [Serializable]
    public class GPFreq : IComparable<GPFreq>
    {
        public GovPattern gp;
        public int freq;
        public GPFreq(GovPattern gp)
        {
            this.gp = gp;
            freq = 1;
        }
        public int CompareTo(GPFreq other)
        {
            int res = gp.wMain.ComparePermMorph(other.gp.wMain);
            if (res != 0)
                return res;
            res = gp.connector.CompareTo(other.gp.connector);
            if (res != 0)
                return res;
            res = gp.wActant.CompareVarMorph(other.gp.wActant);
            if (res != 0)
                return res;
            return gp.actant.CompareTo(other.gp.actant);
        }
        public override string ToString()
        {
            return string.Format("{0} [Freq = {1}]", gp, freq);
        }
    }
    public class GPDictionary
    {
        double eps = 0.0001;
        List<GovPattern> listGp;
        List<GPFreq> listGpFreq;
        public GPDictionary()
        {
            listGp = new List<GovPattern>();
            listGpFreq = new List<GPFreq>();
        }
        public void AddGP(GovPattern gp)
        {
            int i = listGp.BinarySearch(gp);
            if (i >= 0)
                throw new Exception();
            listGp.Insert(~i, gp);
            GPFreq gpf = new GPFreq(gp);
            i = listGpFreq.BinarySearch(gpf);
            if (i >= 0)
                listGpFreq[i].freq++;
            else
                listGpFreq.Insert(~i, gpf);
        }
        public void DelGP(int index)
        {
            GPFreq gpf = new GPFreq(listGp[index]);
            listGp.RemoveAt(index);
            int i = listGpFreq.BinarySearch(gpf);
            listGpFreq[i].freq--;
            if (listGpFreq[i].freq == 0)
                listGpFreq.RemoveAt(i);
        }
        public Actant GetActant(Word wMain, Word wActant, string connector)
        {
            GovPattern gp = new GovPattern(wMain, wActant, Actant.Undef, connector);
            int i = listGp.BinarySearch(gp);
            if (i < 0 && ~i < listGp.Count &&
                listGp[~i].wMain.initial == wMain.initial &&
                listGp[~i].wMain.ComparePermMorph(wMain) == 0 &&
                listGp[~i].wActant.initial == wActant.initial &&
                listGp[~i].wActant.ComparePermMorph(wActant) == 0 &&
                listGp[~i].connector == connector)
                return listGp[~i].actant;
            return Actant.Undef;
        }
        public double[] GetProbabilities(Word wMain, Word wActant, string connector)
        {
            int valMax = Enum.GetValues(typeof(Actant)).Length;
            double[] arrP = new double[valMax - 1];
            int n = 0;
            for (int i = 0; i < arrP.Length; i++)
            {
                int index = listGpFreq.BinarySearch(new GPFreq(new GovPattern(wMain,
                    wActant, (Actant)(i + 1), connector)));
                if (index < 0)
                    arrP[i] = 0;
                else
                {
                    arrP[i] = listGpFreq[index].freq;
                    n += listGpFreq[index].freq;
                }
            }
            for (int i = 0; i < arrP.Length; i++)
            {
                if (n != 0)
                    arrP[i] = 1 - arrP[i] / n;
                else
                    arrP[i] = 1;
                if ((Actant)(i + 1) == Actant.Attribute &&
                    arrP[i] == 1)
                    arrP[i] -= eps;                
            }
            return arrP;
        }
        public void Save(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, listGp);
            bf.Serialize(fs, listGpFreq);
            fs.Close();
        }
        public void Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listGp = (List<GovPattern>)bf.Deserialize(fs);
            listGpFreq = (List<GPFreq>)bf.Deserialize(fs);
            fs.Close();
        }
        public string[] GetList()
        {
            string[] arrStr = new string[listGp.Count];
            for (int i = 0; i < arrStr.Length; i++)
                arrStr[i] = listGp[i].ToString();
            return arrStr;
        }
        public string[] GetFreqList()
        {
            string[] arrStr = new string[listGpFreq.Count];
            for (int i = 0; i < arrStr.Length; i++)
                arrStr[i] = listGpFreq[i].ToString();
            return arrStr;
        }
    }
    [Serializable]
    public class LFArgVal : IComparable<LFArgVal>
    {
        public Word wArg, wVal;
        public LexFunction lf;
        public string param;    // для Conv
        public LFArgVal(Word wArg, Word wVal, LexFunction lf, string param)
        {
            if (wArg == null)
                throw new Exception("Не задан аргумент");
            if (wVal == null)
                throw new Exception("Не задано значение");
            this.wArg = wArg;
            this.wVal = wVal;
            this.lf = lf;
            this.param = param;
        }
        public int CompareTo(LFArgVal other)
        {
            int res = wArg.initial.CompareTo(other.wArg.initial);
            if (res != 0)
                return res;
            res = wArg.ComparePermMorph(other.wArg);
            if (res != 0)
                return res;
            res = wVal.initial.CompareTo(other.wVal.initial);
            if (res != 0)
                return res;
            res = wVal.ComparePermMorph(other.wVal);
            if (res != 0)
                return res;
            res = param.CompareTo(other.param);
            if (res != 0)
                return res;
            return lf.CompareTo(other.lf);
        }
        public override string ToString()
        {
            return string.Format("{0} {1} [ЛФ:{2}, Параметр:{3}]",
                wArg, wVal, lf, param);
        }
    }
    public class LFDictionary
    {
        List<LFArgVal> listLf;
        public LFDictionary()
        {
            listLf = new List<LFArgVal>();
        }
        public void AddLF(LFArgVal lf)
        {
            if (listLf.Count == 0)
            {
                listLf.Add(lf);
                return;
            }
            int i = listLf.BinarySearch(lf);
            if (i >= 0)
                throw new Exception();            
            i = ~i;
            if (i == listLf.Count)
                i--;
            for (int j = i; j < listLf.Count; j++)
                if (listLf[j].wArg.initial != lf.wArg.initial ||
                    !listLf[j].wArg.PermMorphEquals(lf.wArg))
                    break;
                else if (listLf[j].wVal.initial == lf.wVal.initial &&
                    listLf[j].wVal.PermMorphEquals(lf.wVal))
                    throw new Exception();
            for (int j = i; j >= 0; j--)
                if (listLf[j].wArg.initial != lf.wArg.initial ||
                    !listLf[j].wArg.PermMorphEquals(lf.wArg))
                    break;
                else if (listLf[j].wVal.initial == lf.wVal.initial &&
                    listLf[j].wVal.PermMorphEquals(lf.wVal))
                    throw new Exception();
            
            listLf.Insert(i, lf);
        }
        public void DelLF(int index)
        {
            listLf.RemoveAt(index);
        }
        public LexFunction GetLF(Word wArg, Word wVal)
        {
            int i = listLf.BinarySearch(new LFArgVal(wArg,
                wVal, LexFunction.Undef, ""));
            if (~i < listLf.Count &&
                listLf[~i].wArg.initial == wArg.initial &&
                listLf[~i].wArg.PermMorphEquals(wArg) &&
                listLf[~i].wVal.initial == wVal.initial &&
                listLf[~i].wVal.PermMorphEquals(wVal))
                return listLf[~i].lf;
            return LexFunction.Undef;
        }
        public Word GetValParam(Word wArg, LexFunction lf, out string param)
        {
            if (listLf.Count == 0)
            {
                param = "";
                return null;
            }
            int i = listLf.BinarySearch(new LFArgVal(wArg, wArg, lf, ""));
            i = ~i;
            if (i == listLf.Count)
                i--;
            for (int j = i + 1; j < listLf.Count; j++)
                if (listLf[j].wArg.initial != wArg.initial ||
                    !listLf[j].wArg.PermMorphEquals(wArg))
                    break;
                else if (listLf[j].lf == lf)
                {
                    param = listLf[j].param;
                    return (Word)listLf[j].wVal.Clone();
                }
            for (int j = i; j >= 0; j--)
                if (listLf[j].wArg.initial != wArg.initial ||
                    !listLf[j].wArg.PermMorphEquals(wArg))
                    break;
                else if (listLf[j].lf == lf)
                {
                    param = listLf[j].param;
                    return (Word)listLf[j].wVal.Clone();
                }
            
            param = "";
            return null;
        }
        public void Save(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, listLf);
            fs.Close();
        }
        public void Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listLf = (List<LFArgVal>)bf.Deserialize(fs);
            fs.Close();
        }
        public string[] GetList()
        {
            string[] arrStr = new string[listLf.Count];
            for (int i = 0; i < arrStr.Length; i++)
                arrStr[i] = listLf[i].ToString();
            return arrStr;
        }
    }
    /*[Serializable]
    public class Rule
    {
        public STNode root, rootRes; // корни исх. и результ. дерева, в рез. дереве нет предл. и т.д.
        public string comment;
        public STNode[] arrNode;    // узлы исх. дерева
        public LexFunction[] arrLf;    // ЛФ, примен. к узлам исх. дер.
        public Rule(STNode root, STNode rootRes, string comment,
            STNode[] arrNode, LexFunction[] arrLf)
        {
            this.root = root;
            this.rootRes = rootRes;
            this.arrNode = arrNode;
            this.comment = comment;
            this.arrLf = arrLf;
        }
        public bool IsAppliable(STNode node) // для однородн. членов правила не работают
        {
            return CheckIsAppliable(root, rootRes);
        }
        public void ApplyRule()
        {

        }
        bool GetProjections(STNode node, STNode nodeRule,   // корень исх. дерева правила
            out List<STNode> listNode, out List<STNode> listNodeRes) // соотв. узлов рассм. дер. и исх. дер. правила
        {
            if (listNode == null || listNodeRes == null)
            {
                listNode = new List<STNode>();
                listNodeRes = new List<STNode>();
            }
            if (!node.word.PermMorphEquals(nodeRule.word))
                return false;
            listNode.Add(node);
            listNodeRes.Add(nodeRule);
            foreach (STNode child in nodeRule.arrChild)
            {
                int i;
                STNode nd = null;
                for (i = 0; i < node.arrChild.Length; i++)
                {
                    nd = STNode.GetChildren(node.arrChild[i])[0];   // не учит. одн. члены
                    if (nd.actant == child.actant)
                        break;
                }
                if (i == node.arrChild.Length ||
                    !child.word.PermMorphEquals(nd.word) ||
                    !CheckIsAppliable(nd, child))
                    return false;
            }
            return true;
        }
    }*/

    public enum Gender
    {
        Mas, Fem, Neu, Undef
    }
    public enum Number
    {
        Sing, Plur, Undef
    }
    public enum Case
    {
        Nom, Gen, Dat, Acc, Inst, Prep
    }
    public enum Animative
    {
        Anim, Inan
    }
    public enum Degree
    {
        Attr, Comp, Sup, Undef
    }
    public enum Short
    {
        Ful, Sh, Undef
    }
    public enum Aspect
    {
        Imp, Per
    }
    public enum Transitive
    {
        Tran, Intr
    }
    public enum Tense
    {
        Pst, Pre, Fut, Undef
    }
    public enum Person
    {
        Fir, Sec, Thrd, Undef
    }
    public enum LexFunction
    {
        Undef, Syn, Anti, Conv, Adv
    }
    public enum Actant
    {
        Undef, Subject, Object, Addressee, Situant, Attribute
    }

    public class Linearizer
    {
        int[] arrDim;
        int maxIndex;
        public Linearizer(int[] arrDim)
        {
            this.arrDim = arrDim;
            maxIndex = 1;
            for (int i = 0; i < arrDim.Length; i++)
                maxIndex *= arrDim[i];
        }
        public int GetIndex(int[] arrIndex)
        {
            if (arrIndex.Length != arrDim.Length)
                throw new Exception();
            int index = 0, dim = 1;
            for (int i = 0; i < arrDim.Length; i++)
            {
                if (arrIndex[i] >= arrDim[i])
                    throw new Exception();
                index += arrIndex[i] * dim;
                dim *= arrDim[i];
            }
            return index;
        }
        public int[] GetIndexes(int index)
        {
            int[] arrIndex = new int[arrDim.Length];
            int dim = maxIndex;
            for (int i = arrDim.Length - 1; i >= 0; i--)
            {
                dim /= arrDim[i];
                int j = index / dim;
                if (j >= arrDim[i])
                    throw new Exception();
                arrIndex[i] = j;
                index -= j * dim;
            }
            return arrIndex;
        }
    }
    public class MackMethod
    {
        double[,] elements;
        Mark[,] marks;
        int n, clmC, clmD, rowCur;
        double difMin;
        List<int> arrClmA, arrClmB;
        public string iterationResult;
        public MackMethod(double[,] elements)
        {
            this.n = elements.GetLength(0);
            this.elements = elements;
            this.marks = new Mark[n, n];
            this.arrClmA = new List<int>();
            this.arrClmB = new List<int>();
            ClearMarks();
            MarkMinElements();
            FormClmArrays();
        }
        public bool DoIteration()
        {
            iterationResult = "Номера столбцов во множестве A: ";
            foreach (int j in arrClmA)
                iterationResult += j.ToString() + " ";
            iterationResult += "\r\nНомера столбцов во множестве A': ";
            foreach (int j in arrClmB)
                iterationResult += j.ToString() + " ";

            iterationResult += "\r\nМатрица\r\ni / j\t";
            for (int j = 0; j < n; j++)
                iterationResult += j.ToString() + "\t";
            iterationResult += "\r\n";
            for (int i = 0; i < n; i++)
            {
                iterationResult += i.ToString() + "\t";
                for (int j = 0; j < n; j++)
                    switch (marks[i, j])
                    {
                        case Mark.Line:
                            iterationResult += "__" + elements[i, j].ToString() + "__\t";
                            break;
                        case Mark.Points:
                            iterationResult += ".." + elements[i, j].ToString() + "..\t";
                            break;
                        default:
                            iterationResult += "  " + elements[i, j].ToString() + "  \t";
                            break;
                    }
                iterationResult += "\r\n";
            }

            GetMinDif(out rowCur, out clmC, out clmD, out difMin);
            if (rowCur == -1)
                return false;
            iterationResult += "Минимальная неотрицательная разность между " +
                "находящимися в одной строке подчеркнутыми элементами " +
                "столбцов множества A и элементами столбцов множества A' " +
                "равна " + difMin.ToString() + " и достигается в строке " + rowCur.ToString() +
                " для столбца номер " + clmD.ToString() + " из множества A " +
                "(обозначим его C) и столбца " + clmC.ToString() +
                " (из A')\r\n";

            iterationResult += "Увеличиваем элементы матрицы на число " +
                difMin.ToString() + "\r\n";
            IncreaseArrClmA(difMin);
            iterationResult += "Отмечаем элемент матрицы (" + rowCur.ToString() +
                ", " + clmC.ToString() + ") точками\r\n";
            marks[rowCur, clmC] = Mark.Points;

            int count = 0;
            for (int i = 0; i < n; i++)
                if (marks[i, clmC] == Mark.Line)
                    count++;

            iterationResult += "В столбце С находится " +
                count.ToString() + " подчеркнутый(ых) элемент(а)\r\n";
            if (count >= 1)
            {
                iterationResult += "Переводим столбец C (номер " +
                    clmC.ToString() + ") во множество A'\r\n";
                arrClmB.Remove(clmC);
                arrClmA.Add(clmC);
                return true;
            }

            while (true)
            {
                for (int j = 0; j < n; j++)
                    if (marks[rowCur, j] == Mark.Line)
                    {
                        clmD = j;
                        break;
                    }

                marks[rowCur, clmC] = Mark.Line;
                marks[rowCur, clmD] = Mark.NoMark;
                iterationResult += "Столбец номер " +
                    clmD.ToString() + " обозначаем за D, " +
                    "в столбце C подчеркиваем линией элемент (" +
                    rowCur.ToString() + ", " + clmC.ToString() +
                    ") и снимаем подчеркивание в столбце D c элемента (" +
                    rowCur.ToString() + ", " + clmD.ToString() + ")\r\n";

                count = 0;
                int rowNext = -1;
                for (int i = 0; i < n; i++)
                {
                    if (marks[i, clmD] == Mark.Line)
                        count++;
                    if (marks[i, clmD] == Mark.Points)
                        rowNext = i;
                }
                if (count == 0)
                {
                    iterationResult += "Поскольку в столбце D нет подчеркнутых " +
                    "элементов и имеется ровно 1 элемент, отмеченный точками, " +
                    "обозначаем за столбец С столбец номер " +
                    clmC.ToString() + " и выбираем в качестве текущей строку " +
                    rowCur.ToString() + "\r\n";
                    rowCur = rowNext;
                    clmC = clmD;
                }
                else
                {
                    if (count == 1)
                    {
                        bool end = true;
                        for (int j = 0; j < n; j++)
                        {
                            count = 0;
                            for (int i = 0; i < n; i++)
                                if (marks[i, j] == Mark.Line)
                                    count++;
                            if (count == 0)
                                end = false;
                        }
                        if (end)
                            return false;
                    }
                    iterationResult += "Поскольку столбец D содержит другие " +
                        "подчеркнутые элементы, убираем все отметки точками " +
                        "и переформируем множества A и A'";
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            if (marks[i, j] == Mark.Points)
                                marks[i, j] = Mark.NoMark;
                    arrClmA.Clear();
                    arrClmB.Clear();
                    FormClmArrays();
                    break;
                }
            }
            for (int j = 0; j < n; j++)
            {
                count = 0;
                for (int i = 0; i < n; i++)
                    if (marks[i, j] == Mark.Line)
                        count++;
                if (count == 0)
                    return true;
            }
            return false;
        }
        public string GetResult()
        {
            string res = "\r\nОтвет:\r\ni / j\t";
            for (int j = 0; j < n; j++)
                res += j.ToString() + "\t";
            res += "\r\n";
            for (int i = 0; i < n; i++)
            {
                res += i.ToString() + "\t";
                for (int j = 0; j < n; j++)
                    if (marks[i, j] == Mark.Line)
                        res += "x\t";
                    else
                        res += "\t";
                res += "\r\n";
            }
            return res;
        }
        public int[] GetResultIndexes() // возвр. массив номеров столбцов
        {
            int[] arrIndex = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (marks[i, j] == Mark.Line)
                        arrIndex[i] = j;
            return arrIndex;
        }
        void ClearMarks()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    marks[i, j] = Mark.NoMark;
        }
        void MarkMinElements()
        {
            for (int i = 0; i < n; i++)
            {
                int jMin = -1;
                double min = double.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    if (elements[i, j] < min)
                    {
                        jMin = j;
                        min = elements[i, j];
                    }
                }
                marks[i, jMin] = Mark.Line;
            }
        }
        void FormClmArrays()
        {
            int clmA = -1;
            for (int j = 0; j < n; j++)
            {
                int count = 0;
                for (int i = 0; i < n; i++)
                    if (marks[i, j] != Mark.NoMark)
                        count++;
                if (count > 1)
                {
                    arrClmA.Add(j);
                    clmA = j;
                    break;
                }
            }
            for (int j = 0; j < n; j++)
                if (j != clmA)
                    arrClmB.Add(j);
        }
        void GetMinDif(out int row, out int clmC, out int clmD, out double difMin)
        {
            row = -1;
            clmC = -1;
            clmD = -1;
            difMin = double.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                foreach (int j in arrClmA)
                    if (marks[i, j] == Mark.Line)
                        count++;
                if (count == 0)
                    continue;
                double dif = 0;
                int jMinA = -1;
                double min = double.MaxValue;
                foreach (int j in arrClmA)
                {
                    if (elements[i, j] < min)
                    {
                        jMinA = j;
                        min = elements[i, j];
                    }
                }
                dif -= min;

                int jMinB = -1;
                min = double.MaxValue;
                foreach (int j in arrClmB)
                {
                    if (elements[i, j] < min)
                    {
                        jMinB = j;
                        min = elements[i, j];
                    }
                }
                dif += min;
                if (dif >= 0 &&
                    dif < difMin)
                {
                    row = i;
                    difMin = dif;
                    clmC = jMinB;
                    clmD = jMinA;
                }
            }
            return;
        }
        void IncreaseArrClmA(double x)
        {
            foreach (int j in arrClmA)
                for (int i = 0; i < n; i++)
                    elements[i, j] += x;
        }
        public enum Mark
        {
            NoMark, Line, Points
        }
    }
    public class PhraseComparer
    {
        SyntaxAnalysis sa;
        LFDictionary lfDict;
        int ruleCount = 1;
        double penalty = 0.5; // штраф за несовпадение сем. акт.
        public PhraseComparer(SyntaxAnalysis sa, LFDictionary lfDict)
        {
            this.sa = sa;
            this.lfDict = lfDict;
        }
        public double Analize(STNode[] arrRootX, STNode[] arrRootY,
            out STNode[] arrRoot, out double[,] matrCmp,
            out double[,] matrParent, out double[,] matr,
            out int[] arrIndex)
        {
            List<STNode> listNodeX = STNode.GetDescendants(arrRootX);
            List<STNode> listNodeY = STNode.GetDescendants(arrRootY);
            double res = ComparePhrases(arrRootX, arrRootY,
                out matrCmp, out matrParent, out matr, out arrIndex);
            arrRoot = arrRootX;
            for (int i = 0; i < listNodeX.Count; i++)
                for (int j = 0; j < ruleCount; j++)
                {
                    STNode[] arrRootNext = new STNode[arrRootX.Length];
                    for (int k = 0; k < arrRootNext.Length; k++)
                        arrRootNext[k] = STNode.CloneSubTree(arrRootX[k], null);
                    List<STNode> listNodeNext = STNode.GetDescendants(arrRootNext);
                    if (!Rephrase(listNodeNext[i], j))
                        continue;
                    double[,] matrCmpNext, matrParentNext, matrNext;
                    int[] arrIndexNext;
                    double resNext = ComparePhrases(arrRootNext, arrRootY,
                        out matrCmpNext, out matrParentNext,
                        out matrNext, out arrIndexNext);
                    if (resNext > res)
                    {
                        res = resNext;
                        arrRoot = arrRootNext;
                        matrCmp = matrCmpNext;
                        matrParent = matrParentNext;
                        matr = matrNext;
                        arrIndex = arrIndexNext;
                    }
                }
            return res;
        }
        bool Rephrase(STNode nd, int ruleNum)
        {
            if (nd.arrChild == null)
                return false;
            STNode[][] arrArrChild = new STNode[nd.arrChild.Length][];
            for (int i = 0; i < nd.arrChild.Length; i++)
                arrArrChild[i] = STNode.GetChildren(nd.arrChild[i]);
            int subjIndex = -1, objIndex = -1, addrIndex = -1, sitIndex = -1;
            for (int i = 0; i < arrArrChild.Length; i++)
                if (arrArrChild[i] == null)
                    continue;
                else
                    switch (arrArrChild[i][0].actant)
                    {
                        case Actant.Subject:
                            subjIndex = i;
                            break;
                        case Actant.Object:
                            objIndex = i;
                            break;
                        case Actant.Addressee:
                            addrIndex = i;
                            break;
                        case Actant.Situant:
                            sitIndex = i;
                            break;
                    }
            Word wVal;
            string param;
            switch (ruleNum)
            {
                case 0: // Conv
                    wVal = lfDict.GetValParam(nd.word, LexFunction.Conv, out param);
                    if (wVal == null)
                        return false;
                    nd.word = wVal;
                    Actant[] arrActArg, arrActVal;
                    ParseConvParam(param, out arrActArg, out arrActVal);
                    for (int i = 0; i < arrArrChild.Length; i++)
                    {
                        if (arrArrChild[i] == null)
                            continue;
                        for (int j = 0; j < arrActArg.Length; j++)
                            if (arrArrChild[i][0].actant == arrActArg[j])
                            {
                                foreach (STNode child in arrArrChild[i])
                                    child.actant = arrActVal[j];
                                break;
                            }
                    }
                    return true;                

                case 1:
                    wVal = lfDict.GetValParam(nd.word, LexFunction.Adv, out param);
                    if (wVal == null)
                        return false;
                    int index = -1;
                    switch (param)
                    {
                        case "s":
                            index = subjIndex;
                            break;
                        case "o":
                            index = objIndex;
                            break;
                        case "a":
                            index = addrIndex;
                            break;
                        case "t":
                            index = sitIndex;
                            break;
                    }
                    if (index == -1)
                        throw new Exception();
                    List<STNode> listChild = new List<STNode>();
                    for (int i = 0; i < nd.arrChild.Length; i++)
                        if (i != index)
                            listChild.Add(nd.arrChild[i]);
                    STNode ndNew = new STNode(wVal, nd.arrChild[index]);
                    ndNew.actant = Actant.Attribute;
                    listChild.Add(ndNew);
                    if (nd.arrChild[index].arrChild != null)
                        listChild.AddRange(nd.arrChild[index].arrChild);
                    nd.arrChild[index].arrChild = listChild.ToArray();
                    nd.arrChild[index].parent = nd.parent;
                    foreach (STNode child in listChild)
                        child.parent = nd.arrChild[index];
                    return true;
                default:
                    throw new Exception();
            }
        }
        double ComparePhrases(STNode[] arrRootX, STNode[] arrRootY,
            out double[,] matrCmp, out double[,] matrParent,
            out double[,] matr, out int[] arrIndex)
        {
            List<STNode> listNodeX = STNode.GetDescendants(arrRootX);
            List<STNode> listNodeY = STNode.GetDescendants(arrRootY);
            int n = listNodeX.Count;
            if (listNodeX.Count < listNodeY.Count)
                n = listNodeY.Count;
            matrCmp = new double[n, n];
            for (int i = 0; i < listNodeX.Count; i++)
                for (int j = 0; j < listNodeY.Count; j++)
                    matrCmp[i, j] = CompareNodes(listNodeX[i], listNodeY[j]);

            matrParent = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrParent[i, j] = 1;
            for (int i = 0; i < listNodeX.Count; i++)
                for (int j = 0; j < listNodeY.Count; j++)
                {
                    STNode parentX = STNode.GetParent(listNodeX[i].parent);
                    STNode parentY = STNode.GetParent(listNodeY[j].parent);
                    if (parentX == null || parentY == null)
                        matrParent[i, j] = 1;
                    else
                    {
                        int indexParX = listNodeX.IndexOf(parentX);
                        int indexParY = listNodeY.IndexOf(parentY);
                        matrParent[i, j] = Math.Abs(matrCmp[indexParX, indexParY]);
                    }
                }

            matr = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = 1 - matrCmp[i, j] * matrParent[i, j];
            MackMethod mm = new MackMethod((double[,])matr.Clone());
            while (mm.DoIteration()) ;
            arrIndex = mm.GetResultIndexes();
            double res = 0;
            for (int i = 0; i < arrIndex.Length; i++)
                res += 1 - matr[i, arrIndex[i]];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = 1 - matr[i, j];
            return res / n;
        }
        double CompareNodes(STNode ndX, STNode ndY)
        {
            double k = 1;
            if (ndX.actant != ndY.actant)
                k = penalty;
            if (ndX.word.PermMorphEquals(ndY.word) &&
                ndX.word.initial == ndY.word.initial)
                return k * STNode.GetNegation(ndX.parent) *
                    STNode.GetNegation(ndY.parent);
            //if (ndX.word.PermMorphEquals(ndY.word))
                if (sa.CheckSyn(ndX.word.word, ndY.word.word) ||
                    lfDict.GetLF(ndX.word, ndY.word) == LexFunction.Syn)
                    return k * STNode.GetNegation(ndX.parent) *
                        STNode.GetNegation(ndY.parent);
                else if (lfDict.GetLF(ndX.word, ndY.word) == LexFunction.Anti)
                        return -k * STNode.GetNegation(ndX.parent) *
                            STNode.GetNegation(ndY.parent);
            return 0;
        }
        public void ParseConvParam(string param, out Actant[] arrActArg,
            out Actant[] arrActVal)
        {
            string[] arrStr = param.Split(new char[] { ':' });
            if (arrStr.Length != 2 || arrStr[0].Length != arrStr[1].Length)
                throw new Exception();
            arrActArg = ReadActants(arrStr[0]);
            arrActVal = ReadActants(arrStr[1]);
        }
        Actant[] ReadActants(string s)
        {
            List<Actant> listAct = new List<Actant>();
            for (int i = 0; i < s.Length; i++)
            {
                Actant a = Actant.Undef;
                switch (s[i])
                {
                    case 's':
                        a = Actant.Subject;
                        break;
                    case 'o':
                        a = Actant.Object;
                        break;
                    case 'a':
                        a = Actant.Addressee;
                        break;
                    case 't':
                        a = Actant.Situant;
                        break;
                    default:
                        throw new Exception();
                }
                if (listAct.Contains(a))
                    throw new Exception();
                listAct.Add(a);
            }
            return listAct.ToArray();
        }
    }
}