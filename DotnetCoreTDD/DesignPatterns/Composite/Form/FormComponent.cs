using System.Collections.Generic;
using System.Text;
using DotnetCoreTDD.DesignPatterns.Composite.FileSystem;

namespace DotnetCoreTDD.DesignPatterns.Composite.Form
{
    #region Component、Composite、Leaf

    /// <summary>
    /// 元件 抽象類別
    /// </summary>
    public abstract class FormComponent
    {
        public string Text { get; set; }
        protected string TypeName { get; set; }

        public List<FormComponent> Children { get; set; }

        protected FormComponent(string text)
        {
            Text = text;
            Children = new List<FormComponent>();
        }
        
        public string Print()
        {
            return Print(0);
        }
        
        public string Print(int space)
        {
            var indent = space > 0
                ? new string('\t', space)
                : string.Empty;

            var result = new StringBuilder();
            result.Append(indent + "【" + TypeName + "】" + Text + "\n");
            foreach (var child in Children)
            {
                result.Append(child.Print(space + 1));
            }

            return result.ToString();
        }
    }

    /// <summary>
    /// 複合元件 抽象類別
    /// </summary>
    public abstract class FormComposite : FormComponent
    {
        protected FormComposite(string text) : base(text)
        {
        }
        
        /// <summary>
        /// 新增一個子節點
        /// </summary>
        /// <param name="component"></param>
        public FormComposite Add(FormComponent component)
        {
            Children.Add(component);
            return this;
        }

        /// <summary>
        /// 刪除一個子節點
        /// </summary>
        /// <param name="component"></param>
        public void Remove(FormComponent component)
        {
            Children.Remove(component);
        }
    }
    
    /// <summary>
    /// 葉端元件 抽象類別
    /// </summary>
    public abstract class FormLeaf : FormComponent
    {
        protected FormLeaf(string text) : base(text)
        {
        }
    }

    #endregion
    
    /// <summary>
    /// 表單(composite 元件)
    /// </summary>
    public class Form : FormComposite
    {
        public Form(string text) : base(text)
        {
            TypeName = "表單";
        }
    }

    /// <summary>
    /// 題組(composite 元件)
    /// </summary>
    public class QuestionGroup : FormComposite
    {
        public QuestionGroup(string text) : base(text)
        {
            TypeName = "題組";
        }
    }
    
    /// <summary>
    /// 題目-簡答題(leaf 元件)
    /// </summary>
    public class TextAreaQuestion : FormLeaf
    {
        public TextAreaQuestion(string text) : base(text)
        {
            TypeName = "題目(簡答題)";
        }
    }
    
    /// <summary>
    /// 題目-單選題(composite 元件)
    /// </summary>
    public class RadioQuestion : FormComposite
    {
        public RadioQuestion(string text) : base(text)
        {
            TypeName = "題目(選擇題)";
        }
    }
    
    /// <summary>
    /// 題目-多選題(composite 元件)
    /// </summary>
    public class CheckboxQuestion : FormComposite
    {
        public CheckboxQuestion(string text) : base(text)
        {
            TypeName = "題目(多選題)";
        }
    }
    
    /// <summary>
    /// 選項(leaf 元件)
    /// </summary>
    public class QuestionOption : FormComposite
    {
        public QuestionOption(string text) : base(text)
        {
            TypeName = "選項";
        }
    }
}