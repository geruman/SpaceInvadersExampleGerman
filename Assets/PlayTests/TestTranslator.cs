using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestTranslator
    {
        GameObject go;
        Rigidbody2D rb;
        Translator trans;
        Vector3 oldPos;

        [SetUp]
        public void Setup()
        {
            go = new GameObject();
            rb = go.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            trans = go.AddComponent<Translator>();
            oldPos = go.transform.position;
            WaitForAframe();
        }
        public IEnumerator WaitForAframe()
        {
            yield return null;
        }
        [UnityTest]
        public IEnumerator GivenZeroMovementVectorTheGameObjectStaysInPlace()
        {

            

            trans.Move(Vector2.zero);

            yield return new WaitForSeconds(1f); //Allow for velocity to take place

            Assert.AreEqual(oldPos, go.transform.position);
        }
        [UnityTest]
        public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesAsExpected()
        {



            trans.Move(new Vector2(1f, 1f));

            yield return new WaitForSeconds(1f); //Allow for velocity to take place

            //Assert.AreEqual(oldPos.y, go.transform.position.y);
            Debug.Log(go.transform.position.x+ " <<<");
            Assert.IsTrue((1f > go.transform.position.x), "transform.position.x is not 1f as expected");
            Assert.IsTrue((1f > go.transform.position.y), "transform.position.y is not 1f as expected");

        }
        [UnityTest]
        public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesWithoutAceleration()
        {



            trans.Move(new Vector2(1f, 1f));

            yield return new WaitForSeconds(2f); //Allow for velocity to take place

            //Assert.AreEqual(oldPos.y, go.transform.position.y);
            Assert.IsTrue((go.transform.position.x < 1.5f), " Not desacelerating properly");
            Assert.IsTrue((go.transform.position.y < 1.5f), " Not desacelerating properly");

        }
        [UnityTest]
        public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesWithDesaceleration()
        {
            trans.Move(new Vector2(1f, 1f));
            yield return new WaitForSeconds(2f); //Allow for velocity to take place
            //Assert.AreEqual(oldPos.y, go.transform.position.y);
            Assert.IsTrue((go.GetComponent<Rigidbody2D>().velocity.magnitude == 0), " Not desacelerating properly "+go.transform.position.x);

        }

    }
    
    
    
}