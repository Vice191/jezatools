using System;

namespace ProductTracker
{
    public class Price
    {
        public Price()
        {
            Id = Guid.NewGuid();
        }

        public Price(double gross, double net)
        {
            Gross = gross;
            Net = net;
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the gross price for the item.
        /// </summary>
        /// <value>The gross price.</value>
        public double Gross { get; set; }

        /// <summary>
        /// Gets or sets the net price for the item.
        /// </summary>
        /// <value>The net price.</value>
        public double Net { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }
    }
}