namespace nopCommerceApi.Models.Product
{
    public class ProductUpdateBlockDownloadDto : BaseDto
    {
        /// <summary>
        /// ## IsDownload
        /// ### Set a value indicating whether the product is download.
        /// #### Check if the product is downloadable. When customers purchase a downloadable product, they can download it directly from your store. 
        /// #### The link will be visible after checkout. Please note that it's recommended to use the 'Use download URL' feature for large files (instead of uploading them to the database).
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = False*
        /// </summary>
        public virtual bool IsDownload { get; set; }

        /// <summary>
        /// ## DownloadId
        /// ### Set the download identifier from Entity Download.
        /// #### The downloadable products functionality is useful when you are going to sell e-books or audiobooks, courses, PDFs, music, software or you want to create a picture stock, for example.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = 0*
        /// </summary>
        public virtual int DownloadId { get; set; }

        /// <summary>
        /// ## UnlimitedDownloads
        /// ### Set a value indicating whether this downloadable product can be downloaded unlimited number of times.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = false*
        /// </summary>
        public virtual bool UnlimitedDownloads { get; set; }

        /// <summary>
        /// ## MaxNumberOfDownloads
        /// ### the maximum number of downloads. 
        /// #### UnlimitedDownloads has to be false if you want to use this function.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default is 10*
        /// </summary>
        public virtual int MaxNumberOfDownloads { get; set; }

        /// <summary>
        /// ## DownloadExpirationDays
        /// ### Set the number of days during customers keeps access to the file.
        /// #### The number of days during customers keeps access to the file (e.g. 14). 
        /// #### Leave this field null to allow continuous downloads.        
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = null*
        /// </summary>
        public virtual int? DownloadExpirationDays { get; set; }

        /// <summary>
        /// ## DownloadActivationTypeId
        /// ### Set the download activation type.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// ** Defines the download activation type (compatible with 4.70.3) **
        /// * WhenOrderIsPaid (0): Activation occurs when the order is paid. (default setting)
        /// * Manually (10): Activation occurs manually.        
        /// </summary>
        public virtual int DownloadActivationTypeId { get; set; }

        /// <summary>
        /// ## HasSampleDownload
        /// ### Set a value indicating whether the product has a sample download file.
        /// #### You can download file using URL or uploading from the computer. 
        /// #### If you want to download file using URL check the box Use download URL.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Defaul = false*
        /// </summary>
        public virtual bool HasSampleDownload { get; set; }

        /// <summary>
        /// ## SampleDownloadId
        /// ### Set the sample download identifier.
        /// #### Doc: https://docs.nopcommerce.com/en/running-your-store/catalog/products/downloadable-products.html
        /// *Default = 0*
        /// </summary>
        public virtual int SampleDownloadId { get; set; }

        /// <summary>
        /// ## HasUserAgreement
        /// ### Set a value indicating whether the product has user agreement.
        /// *Default = false*
        /// </summary>
        public virtual bool HasUserAgreement { get; set; }

        /// <summary>
        /// ## UserAgreementText
        /// ### Set the text of license agreement.
        /// *Default = null*
        /// </summary>
        public virtual string? UserAgreementText { get; set; }

    }
}
