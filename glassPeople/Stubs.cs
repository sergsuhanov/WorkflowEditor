using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Microsoft.Data.SqlClient {
    public class SqlConnection { }
}

namespace System {
    public class ValueType {

    }
    public class MulticastDelegate {

    }
}

namespace System.Drawing {
    public class Color {

    }
    public class Image {

    }
}

namespace System.Transactions {
    public class TransactionScope {

    }
}

namespace Microsoft.EntityFrameworkCore {
    public class DbSet<T> {
    }

    public class DbContext {
    }
}

namespace Microsoft.AspNetCore.Identity {
    public class IdentityUser {
    }
}

namespace Microsoft.AspNetCore.Identity.EntityFrameworkCore {
    public class IdentityDbContext<T> {
    }
}

namespace Newtonsoft.Json {
    public class JsonIgnoreAttribute : Attribute {
    }
}

namespace glassPeople.ActivityLibrary {

    public enum SelectMode {
        Single,
        Multi
    }

    public enum BookmarkActivityUserAction {
        NextRun,
        Stop,
        Pause
    }

    public enum ListDocumentAction {
        None,
        Add,
        Edit,
        Dublicate,
        Delete,
        Custom
    }

    public enum PeriodDateMode {
        Manual,
        CurrentDay,
        PreviousWeek,
        PreviousMonth
    }

    public abstract class FilterActivity<T> : NativeActivity {

        [Category("Source")]
        public InArgument<List<T>> Source { get; set; }
        [Category("Result")]
        public OutArgument<List<T>> Result { get; set; }

        protected override void Execute(NativeActivityContext context) {

        }

        protected abstract IQueryable<T> GetByDefault(NativeActivityContext context);

        protected abstract List<T> Filter(NativeActivityContext context, IEnumerable<T> source);
    }

    public enum AddRemoveExtraMode {
        AddOrUpdate,
        Add,
        Update,
        Remove,
        Get,
        Filter
    }

    public abstract class AttributesActivity<T> : NativeActivity where T : glassPeople.Model.Dictionaries.AttributeValue {
        public AddRemoveExtraMode Mode { get; set; }
        public OutArgument<List<T>> FiltrationResult { get; set; }
    }

    public enum SelectionMode {
        None,
        Single,
        Multi
    }

    public abstract class ListActivity<T> : CustomActionActivity {
        [Category("Property")]
        public SelectionMode SelectionMode { get; set; }
        [Category("In")]
        public InArgument<List<T>> Source { get; set; }

        [Category("Out")]
        public OutArgument<List<T>> Results { get; set; }
        [Category("Out")]
        public OutArgument<T> Result { get; set; }
    }

    public class ActionItem {
        public string Action { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public abstract class CustomActionActivity : NativeActivity {
        protected override bool CanInduceIdle => true;
        public List<ActionItem> Actions { get; set; } = new List<ActionItem>();
    }
}

