﻿## Bridge 橋接模式

```
bridge 將 抽象上的變化 與 實作上的變化 分開
抽象：abstraction
實作：implementation
```

- 情境：我有X個概念相同的抽象(東西)，對應Y個概念相同的實作
- 實作方向：考慮多型的Strategy
- 價值：用 X+Y 個類別，創造 X*Y 個結果