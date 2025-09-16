using System.Text;

namespace LogLog.Console.State
{
    public abstract class BaseContext : IContext
    {
        protected ContextType _type;

        protected int _id;

        protected string _name = string.Empty;


        public ContextType Type
        {
            get
            {
                return Child != null
                    ? Child.Type
                    : _type;
            }
        }

        public int Id
        {
            get
            {
                return Child != null
                    ? Child.Id
                    : _id;
            }
        }

        public string Name
        {
            get
            {
                return Child != null
                    ? Child.Name
                    : _name;
            }
        }

        public IContext? Child { get; protected set; }


        public virtual void AddContext(IContext child)
        {
            if (Child != null)
            {
                Child.AddContext(child);
            }
            else
            {
                Child = child;
            }
            
        }

        public virtual void RemoveLastContext()
        {
            if (Child != null && Child.Child != null)
            {
                Child.Child.RemoveLastContext();
            }
            else
            {
                Child = null;
            }
        }

        public override string ToString()
        {
            return Child == null
                ? $"{GetContextInfo()}>"
                : $"{GetContextInfo()}/{Child.ToString()}";
        }

        private string GetContextInfo()
        {
            var stb = new StringBuilder();

            stb.Append(_type.ToString());
            stb.Append(GetContextFullName());

            return stb.ToString();
        }

        private string GetContextFullName()
        {
            var name = string.Empty;
            switch(_type)
            {
                case ContextType.Group:
                case ContextType.Task:
                case ContextType.Subtask:
                    name = $"-{_id}:{_name}";
                    break;
                case ContextType.Period:
                    name = $"-{_id}";
                    break;
            }

            return name;
        }
    }
}
