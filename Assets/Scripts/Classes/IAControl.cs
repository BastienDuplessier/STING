//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace AssemblyCSharp
{
		public class IAControl : Control
		{
			GameObject gameObject;

			public IAControl (GameObject gameObject) {
				this.gameObject = gameObject;
			}
		
			public override bool TurningRight() {
				return false;
			}
			
			public override bool TurningLeft() { 
				return false;
			}
			
			public override bool Accelerating() { 
				return true;
			}
			
			public override bool Slowing() { 
				return false;
			}
		}
}
