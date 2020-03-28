namespace StoreTests.ParserTestCases
{
    public class LoremIpsum : ITestCase
    {
        public string Content =>
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Suspendisse imperdiet tellus nibh, ut convallis dui condimentum eget. Cras suscipit est purus, vitae bibendum purus imperdiet nec. Etiam sed dolor elit. Nunc lacus tortor, sodales et felis sed, ultricies blandit massa. 
Fusce lobortis tincidunt dui nec fermentum. In tempus quam ipsum. Etiam lacinia tortor mi, sit amet vehicula sem faucibus efficitur. Suspendisse risus risus, tempus quis laoreet in, ultricies et orci. Fusce massa lacus, blandit sed odio non, volutpat condimentum quam. 
Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur hendrerit tristique felis, nec aliquam justo tincidunt eu.
Sed sed purus at diam tincidunt consectetur non laoreet dolor. Nulla ac lectus eget odio viverra porta. 
Fusce feugiat tincidunt cursus. Nullam nec scelerisque justo, id ornare lacus. In hendrerit, turpis eu laoreet vulputate, erat ligula aliquet velit, at finibus est massa a arcu. Sed eu magna ligula. Nunc vehicula urna et eleifend ultrices. 
Sed laoreet tempus sapien, et mollis urna ultricies sit amet. Fusce sagittis, orci in tempor aliquam, tortor tortor pharetra neque, vel scelerisque mi neque et massa.";
        public int ExpetedItemsAmount => 0;
        public int ExpetedStores => 0;
    }
}
