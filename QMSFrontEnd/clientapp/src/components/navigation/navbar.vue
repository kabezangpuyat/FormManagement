<template>
	<nav id="sidenav">
		<div class="header">
			<img src="@/assets/images/US.png" class="logoUs">
		</div>
		<icontile v-for="route in routes" :key="route.name" :routeinfo="route" />


		<a class="icon" v-bind:style="{'margin-top': 'auto'}" @click="signOut" :key="0"  title="Logout" data-toggle="tooltip">
			<font-awesome-icon :icon="'sign-out-alt'"  />&nbsp;
		</a>
	</nav>
</template>

<script>
	import icontile from '@/components/navigation/navitem.vue';
	import commonservice from '@/services/commonservice.js';
    import { onMounted, computed } from '@vue/composition-api';

	export default{
		setup(){
			const routes = computed(()=>commonservice.getAllNavigations());

			const signOut = async()=>{
				commonservice.clearData();
				commonservice.redirectByName('login');
			}

			onMounted(()=>{
				commonservice.logoutIfUnAuthorize();
			});

			return {routes,signOut}
		},
		components:{icontile}
	}
</script>

<style scoped>
	#sidenav {
		width: 70px;
		height: 100%;
		display: flex;
		flex-direction: column;
		/* background-color: #0096e3; */
		background-color:#3c4b64;
		box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.5);
		padding: 10px 0 0 0;
		margin-left: 0;
	}
	.logoUs{
		/* width:0px;  */
		/* padding-top: 30px; */
		padding-left: 70px;
		padding-right: 75px;
	}
	.header {
		display: flex;
		flex-direction: column;
		height: 100px;
		justify-content: center;
		align-items: center;
		color: white;
		margin-bottom: 30px;
	}

		.header img {
			width: 200px;
			height: auto;
			margin: 20px 0px;
		}
</style>
