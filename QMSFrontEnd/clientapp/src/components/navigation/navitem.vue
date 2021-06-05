<template>
	<router-link class="icon" v-bind:to="routeinfo.path" v-bind:title="routeinfo.displayname"
	:data-toggle="tooltip">
		<font-awesome-icon :icon="routeinfo.meta.icon" v-bind:title="routeinfo.displayname" />
		<!-- &nbsp; {{routeinfo.displayname}} -->
	</router-link>
</template>

<script>
import { ref } from '@vue/composition-api';
export default {
	setup(){
		const tooltip = ref('tooltip');

		return {tooltip}
	},
	props: ["routeinfo"]
};
</script>

<style>
	a.icon {
		font-size: 12px;
		transition-duration: 0.5s;
		text-decoration: none;
		align-items: center;
		justify-content: flex-start;
		padding: 0px 20px;
		margin: 5px;
		height: 30px;
		color: white;
		text-transform: capitalize;
		cursor: pointer;
		display: -webkit-box;
	}

		a.icon.router-link-exact-active {
			/* background-color: white; */
			color: #0096e3;
			height: 1cm;
			box-shadow: inherit rgba(255, 255, 255, 1);
		}
	
</style>
