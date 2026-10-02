Windows Workflow Foundation (WF) runtime to .NET 6. This project is still in the experimental phase.

<img src="./img/img1.png" width="800"/>
<br/>
<img src="./img/img2.png" width="800"/>
<br/>
<img src="./img/img3.jpg" width="800"/>

## Web editor

The Web toolbox currently supports Sequence, Assign, WriteLine, Delay, If, While, and AddToCollection<T>. Sequence, If, and While allow nested activities; If selects the branch for the next added child, and While uses its Body as the child container. Other loaded activities use the generic display-only fallback and are not added to the toolbox.

Assign source/destination and If/While conditions are Visual Basic expressions. AddToCollection selects variables from the active workflow scope. WriteLine text and Delay duration are edited as literal values (Delay uses a TimeSpan string). XAML files can be opened and saved from the Web editor, and built-in workflow validation errors are shown in the UI.
