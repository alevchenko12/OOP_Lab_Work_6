namespace Lab_Work_6
{
    public  class BaseComponent
    {
      
        /// <summary>
        /// віртуальний метод для написання звіту про роботу
        /// </summary>
        /// <returns></returns>
        public virtual string ReportComponent()
        {
            string info = "No info";
            return info;
        }
          
        /// <summary>
        /// віртуальний метод для написання звіту про поломку
        /// </summary>
        /// <returns></returns>
        public virtual string ReportBreackdown()
        {
            string info = "No info about breackdown. Call service center for additional info.";
            return info;
        }

    }
}