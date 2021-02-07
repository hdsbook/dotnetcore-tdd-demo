- EmailFacade: 用來簡化系統中某個子系統的使用方式
- SubSystem: 子系統物件集
    - User: 使用者物件，取得使用者信箱
    - News: 最新消息物件，取得最新消息通知
    - EmailSender: 寄信物件

---

原本系統寄送信件會涉及三個物件的使用，如下：

```C#
var email = (new User()).GetUserEmail(account);
var content = (new News()).GetNewsNotifyContent();
var result = (new EmailSender()).SendEmail(email, content);
```

EmailFacade將其簡化為單一函式介面，如下：

```C#
var result = (new EmailFacade()).SendNewsNotifyEmail(account);
```

EmailFacade簡化的介面使客戶可以更簡易的使用，無需知道細節調用了哪些物件