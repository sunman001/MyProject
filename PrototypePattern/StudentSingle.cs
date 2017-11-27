

namespace PrototypePattern
{
    public class StudentSingle
    {
        private StudentSingle()
        {

        }
        public static StudentSingle _StudentSingle = null;

        static StudentSingle()
        {
            _StudentSingle = new StudentSingle();
        }

        public static StudentSingle CreateInstance()
        {

            return _StudentSingle;
        }

    }
}
