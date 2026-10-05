Windows Workflow Foundation (WF) runtime to .NET 6. This project is still in the experimental phase.

<img src="./img/img1.png" width="800"/>
<br/>
<img src="./img/img2.png" width="800"/>
<br/>
<img src="./img/img3.jpg" width="800"/>

## Web editor

The Web toolbox currently supports Sequence, Assign, WriteLine, Delay, If, While, DoWhile, Parallel, TryCatch (Try, Catch System.Exception, Finally), ForEach<T>, and the collection activities AddToCollection<T>, RemoveFromCollection<T>, ExistsInCollection<T> (Collection and Item only), ClearCollection<T>. Sequence, If, While, and DoWhile allow nested activities; If selects the branch for the next added child, and While and DoWhile use their Body as the child container. Other loaded activities use the generic display-only fallback and are not added to the toolbox.

Assign source/destination and If/While conditions are Visual Basic expressions. AddToCollection selects variables from the active workflow scope. WriteLine text and Delay duration are edited as literal values (Delay uses a TimeSpan string). XAML files can be opened and saved from the Web editor, and built-in workflow validation errors are shown in the UI.
