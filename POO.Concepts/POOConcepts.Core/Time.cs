using System;

namespace POO.Concepts.Core
{
    public class Time
    {
        private int hours, minutes, seconds, milliseconds;
        private bool isValid;

        // 1) Constructor sin parámetros
        public Time() : this(0, 0, 0, 0) { }

        // 2) Constructor con horas
        public Time(int h) : this(h, 0, 0, 0) { }

        // 3) Constructor con horas y minutos
        public Time(int h, int m) : this(h, m, 0, 0) { }

        // 4) Constructor con horas, minutos y segundos
        public Time(int h, int m, int s) : this(h, m, s, 0) { }
        // 5) Constructor con horas, minutos, segundos y milisegundos
        public Time(int h, int m, int s, int ms)
        {
            if (h >= 0 && h < 24 &&
                m >= 0 && m < 60 &&
                s >= 0 && s < 60 &&
                ms >= 0 && ms < 1000)
            {
                hours = h;
                minutes = m;
                seconds = s;
                milliseconds = ms;
                isValid = true;
            }
            else
            {
                isValid = false;
                throw new ArgumentOutOfRangeException("Hora no válida.");
            }
        }

        public override string ToString()
        {
            if (!isValid) return "Hora inválida";

            DateTime time = new DateTime(1, 1, 1, hours, minutes, seconds, milliseconds);
            return time.ToString("hh:mm:ss.fff tt"); // formato no militar
        }
        public long ToMilliseconds()
        {
            if (!isValid) return 0;
            return (((hours * 60L + minutes) * 60L + seconds) * 1000L + milliseconds);
        }

        public long ToSeconds()
        {
            if (!isValid) return 0;
            return (hours * 3600L + minutes * 60L + seconds);
        }

        public long ToMinutes()
        {
            if (!isValid) return 0;
            return (hours * 60L + minutes);
        }

        public bool IsOtherDay(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            return totalMs >= 24L * 3600L * 1000L; // más de un día
        }

        public Time Add(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            totalMs %= 24L * 3600L * 1000L; // si pasa al otro día, lo ajusta

            int h = (int)(totalMs / 3600000); totalMs %= 3600000;
            int m = (int)(totalMs / 60000); totalMs %= 60000;
            int s = (int)(totalMs / 1000); totalMs %= 1000;
            int ms = (int)totalMs;

            return new Time(h, m, s, ms);
        }
    }
}