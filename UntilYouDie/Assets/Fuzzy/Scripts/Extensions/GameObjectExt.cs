using System;
using System.Reflection;
using UnityEngine;

namespace Fuzzy
{
    public class GameObjectExt
    {
        /// <summary>
        /// Used to give the "Awake" Method the ability to accept parameters, and invoke the object based of the parameters given.
        /// </summary>
        /// <param name="newObject">The Object Class to Invoke</param>
        /// <param name="arg">the parameters for said object.</param>
        private static void InvokeParameterisedAwake(GameObject newObject, object[] arg) {
            foreach (MonoBehaviour behaviour in newObject.GetComponents<MonoBehaviour>()) {
                foreach (MethodInfo info in behaviour.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    // | BindingFlags.DeclaredOnly))
                {
                    if (String.CompareOrdinal(info.Name, "Awake") == 0) {
                        ParameterInfo[] parameters = info.GetParameters();
                        if (parameters.Length == arg.Length) {
                            bool typesMatch = true;
                            for (int i = 0; i < (parameters.Length); i++) {
                                if (parameters[i].ParameterType != arg[i].GetType()) {
                                    typesMatch = false;
                                }
                            }

                            if (typesMatch == true) {
                                info.Invoke(behaviour, arg);
                            }

                        }

                    }
                }
            }
        }

        public static GameObject Instantiate(GameObject O, params object[] arg) {
            GameObject newObject = GameObject.Instantiate(O) as GameObject;

            InvokeParameterisedAwake(newObject, arg);
            return newObject;
        }
    }
}