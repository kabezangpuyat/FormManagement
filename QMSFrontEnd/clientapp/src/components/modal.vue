<template>
  <div class="modal-form">
    <div class="title">Call Type</div>
    <div class="field">
      <label>Description</label>
    </div>
    <div class="form-buttons">
      <button  class=""><font-awesome-icon icon="times" />Cancel</button>
      <button @click="save" class=""><font-awesome-icon icon="save" />Save</button>
    </div>
  </div>
</template>

<script>
export default {
    methods: {
        save: function() {
            this.$emit('click');
        }

    }
}
</script>