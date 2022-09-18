using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Composite.FileSystem
{
    public abstract class FileSystemComponent
    {
        public string Name { get; set; }
        public List<FileSystemComponent> Children { get; set; }

        protected FileSystemComponent(string name)
        {
            Name = name;
            Children = new List<FileSystemComponent>();
        }

        public string Print(int indentNum = 0)
        {
            var indentString = indentNum > 0
                ? new string('\t', indentNum)
                : string.Empty;
            
            var result = new StringBuilder();
            result.Append(indentString + Name + "\n");
            foreach (var child in Children)
            {
                result.Append(child.Print(indentNum + 1));
            }

            return result.ToString();
        }
    }

    public class Directory : FileSystemComponent
    {
        public Directory(string name) : base(name)
        {
        }
        
        /// <summary>
        /// 新增一個子節點
        /// </summary>
        /// <param name="node"></param>
        public void Add(FileSystemComponent node)
        {
            Children.Add(node);
        }

        /// <summary>
        /// 刪除一個子節點
        /// </summary>
        /// <param name="node"></param>
        public void Remove(FileSystemComponent node)
        {
            Children.Remove(node);
        }
    }

    public class File : FileSystemComponent
    {
        public File(string name) : base(name)
        {
        }
    }
}