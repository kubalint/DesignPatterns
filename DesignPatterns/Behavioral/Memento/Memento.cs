namespace DesignPatterns.Behavioral.Memento
{
    using System;

    // Originator
    class Editor
    {
        private string content;

        public Editor()
        {
            this.content = "";
        }

        public void Type(string words)
        {
            this.content += " " + words;
        }

        public string GetContent()
        {
            return this.content;
        }

        public EditorMemento Save()
        {
            return new EditorMemento(this.content);
        }

        public void Restore(EditorMemento memento)
        {
            this.content = memento.GetContent();
        }
    }

    // Memento
    class EditorMemento
    {
        private readonly string content;

        public EditorMemento(string content)
        {
            this.content = content;
        }

        public string GetContent()
        {
            return this.content;
        }
    }

    // Caretaker
    class History
    {
        private readonly Editor editor;
        private readonly Stack<EditorMemento> mementos;

        public History(Editor editor)
        {
            this.editor = editor;
            this.mementos = new Stack<EditorMemento>();
        }

        public void Backup()
        {
            this.mementos.Push(this.editor.Save());
        }

        public void Undo()
        {
            if (this.mementos.Count == 0) return;

            EditorMemento memento = this.mementos.Pop();
            this.editor.Restore(memento);
        }
    }

    // Example usage
    public static class MementoClient
    {
        public static void Run()
        {
            Editor editor = new Editor();
            History history = new History(editor);

            // Type some content
            editor.Type("This is the first sentence.");
            editor.Type("This is the second sentence.");

            // Save the state
            history.Backup();

            // Type some more content
            editor.Type("This is the third sentence.");

            // Oops, we made a mistake, undo the last action
            history.Undo();

            Console.WriteLine(editor.GetContent()); 
            // Output: This is the first sentence. This is the second sentence.
        }

        /*
            The Memento design pattern is a behavioral design pattern that allows you to save and restore the state of an object to a previous state. 
            This pattern is useful when you need to restore an object to a previous state, or when you need to undo a series of actions.

            The Memento pattern involves three main components:

            + The Originator: 
                The object that needs to be saved and restored.

            + The Memento: 
                An object that stores the state of the Originator.

            + The Caretaker: 
                The object that is responsible for saving and restoring the state of the Originator using the Memento.


            In this example, the Editor class is the Originator, the EditorMemento class is the Memento, and the History class is the Caretaker. 
            The Editor class has a Save method that creates an EditorMemento object to store the current state of the editor. 
            The Editor class also has a Restore method that restores the editor's state from an EditorMemento object. 
            The History class is responsible for managing the EditorMemento objects using a stack. 
            The Backup method saves the current state of the editor to an EditorMemento object and pushes it onto the stack. 
            The Undo method pops the top EditorMemento object from the stack and restores the editor's state from it.
         */
    }
}
