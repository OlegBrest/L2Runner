namespace L2Runner
{
    public class KeyCodes
    {
        
        public static uint getCode(string _key)
        {
            uint res = 0;
            switch (_key)
            {
                case "D1":
                    res = 0x02;
                    break;
                case "D2":
                    res = 0x03;
                    break;
                case "D3":
                    res = 0x04;
                    break;
                case "D4":
                    res = 0x05;
                    break;
                case "D5":
                    res = 0x06;
                    break;
                case "D6":
                    res = 0x07;
                    break;
                case "D7":
                    res = 0x08;
                    break;
                case "D8":
                    res = 0x09;
                    break;
                case "D9":
                    res = 0x0A;
                    break;
                case "D0":
                    res = 0x0B;
                    break;
                case "OemMinus":
                    res = 0x0C;
                    break;
                case "Oemplus":
                    res = 0x0D;
                    break;
                case "F1":
                    res = 0x3B;
                    break;
                case "F2":
                    res = 0x3C;
                    break;
                case "F3":
                    res = 0x3D;
                    break;
                case "F4":
                    res = 0x3E;
                    break;
                case "F5":
                    res = 0x3F;
                    break;
                case "F6":
                    res = 0x40;
                    break;
                case "F7":
                    res = 0x41;
                    break;
                case "F8":
                    res = 0x42;
                    break;
                case "F9":
                    res = 0x43;
                    break;
                case "F10":
                    res = 0x44;
                    break;
                case "F11":
                    res = 0x57;
                    break;
                case "F12":
                    res = 0x58;
                    break;
                case "NumPad1":
                    res = 0x4F;
                    break;
                case "NumPad2":
                    res = 0x50;
                    break;
                case "NumPad3":
                    res = 0x51;
                    break;
                case "NumPad4":
                    res = 0x4B;
                    break;
                case "NumPad5":
                    res = 0x4C;
                    break;
                case "NumPad6":
                    res = 0x4D;
                    break;
                case "NumPad7":
                    res = 0x47;
                    break;
                case "NumPad8":
                    res = 0x4;
                    break;
                case "NumPad9":
                    res = 0x49;
                    break;
                case "NumPad0":
                    res = 0x52;
                    break;
                case "Divide":
                    res = 0x0135;
                    break;
                case "Multiply":
                    res = 0x37;
                    break;
            }
            return res;
        }
    }
}
