// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using Microsoft.CodeAnalysis;

namespace WorkflowEditor.Win {
    public class QueryCompletionData : ICompletionData {
        private static readonly ImageSource MethodIcon;
        private static readonly ImageSource PropertyIcon;
        private static readonly ImageSource FieldIcon;
        private static readonly ImageSource EventIcon;

        private readonly IconType iconType;

        static QueryCompletionData() {
            MethodIcon = GetImageSourceFromResource("Method.png");
            PropertyIcon = GetImageSourceFromResource("Property.png");
            FieldIcon = GetImageSourceFromResource("Field.png");
            EventIcon = GetImageSourceFromResource("Event.png");
        }

        internal static ImageSource GetImageSourceFromResource(string resourceName) {
            return BitmapFrame.Create(typeof(QueryCompletionData).Assembly.GetManifestResourceStream(typeof(QueryCompletionData).Namespace + "." + resourceName));
        }

        public QueryCompletionData(string name, ISymbol[] symbols) {
            Text = name;
            switch (symbols[0].Kind) {
                case SymbolKind.Event: iconType = IconType.Event; break;
                case SymbolKind.Field: iconType = IconType.Field; break;
                case SymbolKind.Method: iconType = IconType.Method; break;
                case SymbolKind.Property: iconType = IconType.Property; break;
            }
        }

        public ImageSource Image {
            get {
                switch (iconType) {
                    case IconType.Event: return EventIcon;
                    case IconType.Field: return FieldIcon;
                    case IconType.Property: return PropertyIcon;
                    default: return MethodIcon;
                }
            }
        }

        public string Text { get; private set; }

        // Use this property if you want to show a fancy UIElement in the list.
        public object Content {
            get { return Text; }
        }

        public object Description {
            get { return "Description for " + Text; }
        }

        public void Complete(TextArea textArea, ISegment completionSegment,
            EventArgs insertionRequestEventArgs) {
            textArea.Document.Replace(completionSegment, Text);
        }

        public double Priority {
            get { return 1.0; }
        }

        private enum IconType {
            Property,
            Field,
            Method,
            Event,
        }
    }
}
