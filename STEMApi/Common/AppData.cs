using Models;

namespace Common
{
    public class AppData
    {
        //Fields to save the data for the current session
        public static JSONInput JsonInput = new JSONInput();
        public static List<TestVector> TestVectors = new List<TestVector>();
        public static List<TestVector> DummyTestVectors = new List<TestVector>() {
                        new TestVector{Id = 1, SelectedInput = new List<SelectedInput>()
                            {
                                new SelectedInput { InputConditionId = 1, Value = 1},
                                new SelectedInput { InputConditionId = 2, Value = 8},
                            }
                        },
                        new TestVector{Id = 2, SelectedInput = new List<SelectedInput>()
                            {
                                new SelectedInput { InputConditionId = 1, Value = 10},
                                new SelectedInput { InputConditionId = 2, Value = 7},
                            }
                        }
                    };
    }
}