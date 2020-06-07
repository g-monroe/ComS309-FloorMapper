using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class StudioTests
    {
        [TestMethod()]
        public void StudioCreateNotNull()
        {
            Studio temp = new Studio();
            Assert.IsNotNull(temp);
        }
        [TestMethod()]
        public void StudioVectorCreate()
        {
            Studio temp = new Studio();
            Studio.Vector newV= new Studio.Vector();
            newV.Data = "Data";
            newV.Type = "I";
            newV.Index = 0;
            newV.Location = new System.Drawing.Point(0, 0);
            newV.Selected = false;
            temp.Vectors.Add(newV);
            Assert.AreEqual(1, temp.Vectors.Count);
            Assert.AreEqual("Data", temp.Vectors[0].Data);
            Assert.AreEqual("I", temp.Vectors[0].Type);
            Assert.AreEqual(0, temp.Vectors[0].Index);
            Assert.AreEqual(new System.Drawing.Point(0,0), temp.Vectors[0].Location);
        }
        [TestMethod()]
        public void StudioEdgeCreate()
        {
            Studio temp = new Studio();
            System.Drawing.Point edge = new System.Drawing.Point(0, 1);
            System.Drawing.Point edge1 = new System.Drawing.Point(1, 2);
            System.Drawing.Point edge2 = new System.Drawing.Point(2, 3);
            System.Drawing.Point edge3 = new System.Drawing.Point(3, 1);
            temp.Edges.Add(edge);
            temp.Edges.Add(edge1);
            temp.Edges.Add(edge2);
            temp.Edges.Add(edge3);
            Assert.AreEqual(edge.X, temp.Edges[0].X);
            Assert.AreEqual(edge.Y, temp.Edges[0].Y);
            //Loop Backs
            Assert.AreEqual(edge3.Y, temp.Edges[0].Y);
            Assert.AreEqual(edge2.Y, temp.Edges[3].X);
            Assert.AreEqual(edge3.X, temp.Edges[2].Y);
        }
        [TestMethod()]
        public void StudioLoadJSON()
        {
            Studio temp = new Studio();
            temp.loadJSON(true, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/gilman data2.json");
            Assert.AreEqual(86, temp.Vectors.Count);
            Assert.AreEqual(0, temp.Edges.Count);
        }
        [TestMethod()]
        public void StudioLoadJSON2()
        {  
            Studio temp = new Studio();
            temp.loadJSON(false, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/gilman data2.json");
            Assert.AreEqual(86, temp.Vectors.Count);
            Assert.AreEqual(122, temp.Edges.Count);
        }
    }
}