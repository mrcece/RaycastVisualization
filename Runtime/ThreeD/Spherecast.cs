﻿using UnityEngine;
using UnityEngine.Internal;

namespace Nomnom.RaycastVisualization.ThreeD {
	internal static class Spherecast {
		public static bool Run(
			Vector3 origin,
			float radius,
			Vector3 direction,
			out RaycastHit hit,
			[DefaultValue("Mathf.Infinity")] float maxDistance,
			[DefaultValue("DefaultRaycastLayers")] int layerMask,
			[DefaultValue("QueryTriggerInteraction.UseGlobal")]
			QueryTriggerInteraction queryTriggerInteraction) {

			bool didHit = Physics.defaultPhysicsScene.SphereCast(origin, radius, direction, out hit, maxDistance, layerMask,
				queryTriggerInteraction);

#if UNITY_EDITOR
			direction.Normalize();
			Color color = VisualUtils.GetColor(didHit);
			float distance = VisualUtils.GetMaxRayLength(maxDistance);
			VisualUtils.DrawArrow(origin, direction * distance, VisualUtils.GetDefaultColor());

			if (didHit) {
				VisualUtils.DrawNormalCircle(hit.point, hit.normal, color);
				VisualUtils.DrawSphere(origin + direction * hit.distance, radius, color);
			} else {
				VisualUtils.DrawSphere(origin + direction * distance, radius, color);
			}
#endif

			return didHit;
		}

		public static bool Run(
			Vector3 origin,
			float radius,
			Vector3 direction,
			out RaycastHit hit,
			float maxDistance,
			int layerMask) {
			return Run(origin, radius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Run(
			Vector3 origin,
			float radius,
			Vector3 direction,
			out RaycastHit hit,
			float maxDistance) {
			return Run(origin, radius, direction, out hit, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Run(
			Vector3 origin,
			float radius,
			Vector3 direction,
			out RaycastHit hit) {
			return Run(origin, radius, direction, out hit, float.PositiveInfinity, -5,
				QueryTriggerInteraction.UseGlobal);
		}

		/// <summary>
		///   <para>Casts a sphere along a ray and returns detailed information on what was hit.</para>
		/// </summary>
		/// <param name="ray">The starting point and direction of the ray into which the sphere sweep is cast.</param>
		/// <param name="radius">The radius of the sphere.</param>
		/// <param name="maxDistance">The max length of the cast.</param>
		/// <param name="layerMask">A that is used to selectively ignore colliders when casting a capsule.</param>
		/// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
		/// <returns>
		///   <para>True when the sphere sweep intersects any collider, otherwise false.</para>
		/// </returns>
		public static bool Run(
			Ray ray,
			float radius,
			[DefaultValue("Mathf.Infinity")] float maxDistance,
			[DefaultValue("DefaultRaycastLayers")] int layerMask,
			[DefaultValue("QueryTriggerInteraction.UseGlobal")]
			QueryTriggerInteraction queryTriggerInteraction) {
			return Run(ray.origin, radius, ray.direction, out RaycastHit _, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static bool Run(Ray ray, float radius, float maxDistance, int layerMask) {
			return Run(ray, radius, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Run(Ray ray, float radius, float maxDistance) {
			return Run(ray, radius, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Run(Ray ray, float radius) {
			return Run(ray, radius, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Run(
			Ray ray,
			float radius,
			out RaycastHit hitInfo,
			[DefaultValue("Mathf.Infinity")] float maxDistance,
			[DefaultValue("DefaultRaycastLayers")] int layerMask,
			[DefaultValue("QueryTriggerInteraction.UseGlobal")]
			QueryTriggerInteraction queryTriggerInteraction) {
			return Run(ray.origin, radius, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static bool Run(
			Ray ray,
			float radius,
			out RaycastHit hitInfo,
			float maxDistance,
			int layerMask) {
			return Run(ray, radius, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Run(
			Ray ray,
			float radius,
			out RaycastHit hitInfo,
			float maxDistance) {
			return Run(ray, radius, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Run(Ray ray, float radius, out RaycastHit hitInfo) {
			return Run(ray, radius, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}
	}
}