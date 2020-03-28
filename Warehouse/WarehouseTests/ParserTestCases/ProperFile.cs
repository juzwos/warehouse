﻿namespace StoreTests.ParserTestCases
{
    public class ProperFile : ITestCase
    {
        public string Content =>
            @"# Material inventory initial state as of Jan 01 2018
# New materialsCherry 
Hardwood Arched Door -PS;COM-100001;WH-A,5|WH-B,10
Maple Dovetail Drawerbox;COM-124047;WH-A,15
Generic Wire Pull;COM-123906c;WH-A,10|WH-B,6|WH-C,2
Yankee Hardware 110 Deg. Hinge;COM-123908;WH-A,10|WH-B,11
# Existing materials, restocked
Hdw Accuride CB0115-CASSRC -Locking Handle Kit -Black;CB0115-CASSRC;WH-C,13|WH-B,5
Veneer -Charter Industries -3M Adhesive Backed -Cherry 10mm -Paper Back;3M-Cherry-10mm;WH-A,10|WH-B,1
Veneer -Cherry Rotary 1 FSC;COM-123823;WH-C,10
MDF, CARB2, 1 1/8""; COM-101734; WH-C,8";

        public int ExpetedItemsAmount => 14;
        public int ExpetedStores => 3;
    }
}
