<template>
    <div class="modal-form">
        <div class="title">View Case Type</div>
        <div class="field">
            <label>Description </label>
            <label>{{this.calltype.description}} </label>
        </div>
        <div class="field">
            <label>LOB</label>
            <multiselect v-model="calltypelobs" :options="calltypelobs" label="loB" track-by="loB" :multiple="true" :taggable="true" disabled :width="100"></multiselect>
        </div>
    </div>
</template>

<script>
export default {
    mounted() {
        this.calltype = this.existingCallType;
        this.$store.dispatch('calltype/getCallTypeLoB', {id : this.calltype.id});
    },
    data() {
        return {
            calltype: {
                id: 0,
                calltypeId: this.calltypeId,
                description: ""
            },
            lobs: []
        }
               
    },
    computed: {
        calltypelobs(){
            return this.$store.getters['calltype/getAllCallTypeLoB'];
        }
    },
    methods: {
        addTag (newTag) {
            const tag = {
                name: newTag,
                code: newTag.substring(0, 2) + Math.floor((Math.random() * 10000000))
            }
            this.options.push(tag)
            this.value.push(tag)
        }
    },
    props: ["calltypeId", "existingCallType"]
}
</script>

<style>

</style>