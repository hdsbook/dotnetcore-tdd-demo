## Builder 建造者模式

```
建造者 (Builder) 模式將物件的「建構」與「表示」分離，隱藏並封裝建構過程的細節。

它讓我們可以將物件本身拆解成不同的元件，一步一步建造每一部分，最後產生出我們想要的複雜物件。
```

- 情境：
  - 有一個複雜物件要建構
  - 建構子拖太長
  - 建構子不須要的值要放NULL


### 重構前

```C#
// create directly (太多預設值要填入)
var cell = new Cell{
  Text="一些文字", 
  Colspan=1, 
  Rowspan=1, 
  Color="red", 
  Align="center"
};

// or use factory (但這樣的建構子太長，且有太多預設值要填入)
var cell = CellFactory.CreateCell(
    Text: "一些文字", 
    Colspan: 1, 
    Rowspan:1, 
    Color: "red", 
    Align: "center"
);
```

### 重構後

```C#
// colspan 和 rowspan 的預設值是1，所以不用設定
var cell = new CellBuilder("一些文字")
    .Color("red")
    .Align("center")
    .Build();
    
    
// 甚至可以為這組樣式客製化一個自訂義的build option
var cell = new CellBuilder("一些文字")
    .SetMyRedCenterStyle()
    .Build();
```
